net = net or {}

-- 协议类型
local OPCODE_OPEN  = 0 -- 链路打开
local OPCODE_CLOSE = 1 -- 链路关闭
local OPCODE_PING  = 2 -- ping指令
local OPCODE_PONG  = 3 -- pong指令
local OPCODE_DATA  = 4 -- 数据消息
local OPCODE_TURN  = 5 -- 切换线路 |1byte|string bytes| => |数据类型|连接地址| => |0|1.1.1.1:53|
local OPCODE_NOOP  = 6 -- 链路踢出


function net.NewBinaryProtocol()
    local self = {}
    self.buffer = ''
    self.startParse = false
    function self.Read(data)
        --string.concat
        if string.len(self.buffer) == 0 then
            self.buffer = data
        else
            self.buffer = self.buffer .. data
            -- print('total len:', string.len(self.buffer), self.startParse)
        end
        if not self.startParse then
            -- 尝试解析数据头
            if string.len(self.buffer) < 4 then
                return
            end -- 数据不足
            local h1 = string.byte(self.buffer, 1, 1)
            local h2 = string.byte(self.buffer, 2, 2)
            local h3 = string.byte(self.buffer, 3, 3)
            local h4 = string.byte(self.buffer, 4, 4)
            local len = h2 << 16 | h3 << 8 | h4
            self.startParse = true
            self.msgLen = len
            self.msgType = h1
            -- copy other bytes
            self.buffer = string.char(string.byte(self.buffer, 5, string.len(self.buffer)))
        end

        if self.startParse then -- start parse body
            if string.len(self.buffer) < self.msgLen then
                return
            end

            local bodyBytes = string.char( string.byte(self.buffer, 1, self.msgLen) )
            self.buffer = string.char(string.byte(self.buffer, self.msgLen + 1, string.len(self.buffer)))
            self.msgLen = 0
            self.startParse = false
            if self.msgType == OPCODE_DATA then
                self.OnMessage(bodyBytes)
            end
        end
    end

    function self.Write(body, cb)
        -- header
        local len = string.len(body)
        local h1 = 0
        local h2 = (len & 0x00ff0000) >> 16
        local h3 = (len & 0x0000ff00) >> 8
        local h4 = (len & 0x000000ff)
        local all = string.char(h1, h2, h3, h4, string.byte(body, 1, len))
        cb(all)
    end

    function self.Update()

    end

    function self.Release()

    end

    return self
end