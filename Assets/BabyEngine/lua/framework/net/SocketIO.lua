local CSSocketIO = CS.Dpoch.SocketIO.SocketIO
function SocketIO(url)
    local self = {}

    local socket

    function self.Connect()
        socket:Connect()
    end
    local function OnOpen()
        if self.OnOpen then self.OnOpen() end
    end
    local function OnClose()
        if self.OnClose then self.OnClose() end
    end
    local function OnError(ex)
        if self.OnError then self.OnError(ex) end
    end
    local function OnConnectFailed()
        if self.OnConnectFailed then self.OnConnectFailed() end
    end

    function self.Release()
        socket:OnOpen('-', OnOpen)
        socket:OnClose('-', OnClose)
        socket:OnError('-', OnError)
        socket:OnConnectFailed('-', OnConnectFailed)
    end

    function self.EmitACK( ev, data, cb )
        socket:EmitACK(ev, function(ack)
            local result
            if ack and ack.data and ack.data.Count > 0 then
                result = ack.data[0]:ToString()
            end
            cb(result)
        end, data)
    end

    socket = CSSocketIO(url)
    socket:OnOpen('+', OnOpen)
    socket:OnClose('+', OnClose)
    socket:OnError('+', OnError)
    socket:OnConnectFailed('+', OnConnectFailed)
    return self
end
