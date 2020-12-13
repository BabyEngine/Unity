net = net or {}
local stateInit         = 0 -- 初始化
local stateConnecting   = 1 -- 开始连接服务器
local stateConnected    = 2 -- 已连接
local stateClosed       = 3 -- 连接主动关闭
local stateLost         = 4 -- 连接丢失
local stateTimeout      = 5 -- 开始连接的超时

local NetworkStatus = {}
setmetatable(NetworkStatus, NetworkStatus)
local stateMap = {
    [1] = 'Init',
    [2] = 'Connecting',
    [3] = 'Connected',
    [4] = 'Closed',
    [5] = 'Lost',
    [6] = 'Timeout',
}
function NetworkStatus.__call(t, val)
    local o = setmetatable({}, NetworkStatus)
    o.state = val
    return o
end

function NetworkStatus.__tostring(t)
    return stateMap[t.state] or 'Unknow State'
end


-- time stuff
local lostTimeout  = 10 -- 超过这个时间没收到消息, 认为链路丢失
local pingInterval = 5  -- 间隔n秒向服务器发送ping指令, 用以保活
local connTimeout  = 10 -- 开始连接的超时时间

function net.NewKCPBinaryClient(address, port)
    local self = {
        lastPingTime = -5,
        latency  = 0,
        startPingTime = 0
    }
    local originAddress = address
    local originPort    = port
    local kcp = CS.uKCP.KCPClient()
    local p = net.NewBinaryProtocol()
    local lastSeen = Time.time
    local hasConnected = false
    local startConnectTime = Time.time
    local hasUpdateRepeat = true
    local sendPing
    local reqId = 0
    local reqMap = {}
    self.networkChangeListener = NewListener()
    -- 消息处理
    local function onMsgOpen(msgType, msg)
        if self.OnOpen then
            hasConnected = true
            self.changeState(stateConnected)
            self.OnOpen(msg)
            return
        end
    end
    local function onMsgPong(msgType, msg)
        self.latency = math.floor((Time.time - self.startPingTime) * 1000)
    end
    local function onMsgData(msgType, msg)
        if self.OnData then
            self.OnData(msg)
        end
    end
    local function onMsgTurn(msgType, msg)
        local tokens = string.split(msg, ':')
        if #tokens == 2 then
            address = tokens[1]
            port = tonumber(tokens[2])
            print('切换地址', address, port)
            hasConnected = false
            self.Connect()
        end
    end
    local function onMsgRESP(msgType, msg)
        local reqId, data = p.DecodeRequest(msg)
        local opt = reqMap[reqId]
        if opt then
            reqMap[reqId] = nil -- 已回复就删除回调
            opt.cb(data)
        end
    end

    local msgMap = {
        [0] = onMsgOpen,
        [3] = onMsgPong,
        [4] = onMsgData,
        [5] = onMsgTurn,
        [8] = onMsgRESP,
    }

    p.OnMessage = function(msgType, msg)
        lastSeen = Time.time
        local cb = msgMap[msgType]
        if cb then
            cb(msgType, msg)
            return
        end
        print('收到未知消息', msgType, msg)
    end

    kcp.OnError = function(err)
        hasConnected = false
        if self.OnError then
            self.OnError(err)
        end
    end

    kcp.OnData = function(data)
        p.Read(data)
    end

    kcp.OnOpen = function()
        -- isConnect = true
        -- if self.OnOpen then
        --     self.OnOpen()
        -- end
    end

    function self.changeState(newState)
        if self.state == newState then return end
        local oldState = self.state
        self.state = newState
        -- print('状态改变', newState)
        if newState == stateLost then
            Looper.AfterFunc(2, self.Connect)
        end

        if newState == stateTimeout then
            address = originAddress
            port    = originPort
            Looper.AfterFunc(2, self.Connect)
        end
        -- self.networkChangeListener.Call(oldState, newState)
        self.networkChangeListener.Call(NetworkStatus(oldState), NetworkStatus(newState))
    end


    function self.Release()
        kcp:Close()
        Looper.RemoveUpdate(self.Update)
    end
    function self.CheckConnection()
        if Time.time - lastSeen > lostTimeout then
            print('网络超时...')
            self.changeState(stateLost)
            hasConnected = false
            return
        end
    end
    function self.Update()
        if kcp then
            kcp:Update()
        end
        if self.state == stateConnecting then -- 正在连接中, 检查连接超时
            if Time.time - startConnectTime > 10 then
                self.changeState(stateTimeout)
                return
            end
        end
        if self.state == stateConnected then -- 已经连接上
            -- 检查上一次消息
            self.CheckConnection()
            -- 需要定时发送ping, keepalive
            if Time.time - self.lastPingTime >= pingInterval then
                self.lastPingTime = Time.time
                sendPing()
            end
        end
    end

    function self.Connect()
        if self.state == stateConnected then -- 先主动放弃先前的链路
            self.SendNoop()
        end
        if hasConnected then return end

        if not hasUpdateRepeat then
            -- 如果连接时发现没有 update 回调,
            -- 需要重新加入 update 回调
            hasUpdateRepeat = true
            Looper.AddUpdate(self.Update)
        end

        startConnectTime = Time.time
        self.changeState(stateConnecting)
        kcp:Connect(address, port)
        sendPing()
    end

    function self.Send( data )
        self.CheckConnection()
        p.Write(4, data, function(bin)
            kcp:Send(bin)
        end)
    end
    -- 主动断开
    function self.SendNoop()
        self.CheckConnection()
        p.Write(6, nil, function(bin)
            kcp:Send(bin)
        end)
        self.changeState(stateClosed)
        Looper.RemoveUpdate(self.Update)
        hasUpdateRepeat = false
    end

    function self.Request( data, cb )
        self.CheckConnection()
        local id = reqId
        reqMap[id] = {
            cb = cb,
        }
        -- 先写入一个 | req id | data |
        local all = p.EncodeRequest(reqId, data)
        p.Write(7, all, function(bin)
            kcp:Send(bin)
        end)
        reqId = reqId + 1
        return id
    end

    -- 发送ping指令
    sendPing = function ()
        self.startPingTime = Time.time
        local data = Int32ToBytes(self.latency)
        if data then
            p.Write(2, data, function(bin)
                kcp:Send(bin)
            end)
        end
    end
    self.state = stateInit
    Looper.AddUpdate(self.Update)
    hasUpdateRepeat = true
    return self
end
