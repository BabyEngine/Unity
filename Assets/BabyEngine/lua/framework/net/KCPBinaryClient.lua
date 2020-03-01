net = net or {}

function net.NewKCPBinaryClient(address, port)
    local self = {}
    local go = CS.UnityEngine.GameObject()
    local kcp = go:AddComponent(typeof(CS.uKCP.KCPClient))
    local reader = net.NewBinaryProtocol()
    reader.OnMessage = function(msg)
        print('收到消息', msg)
        if self.OnMessage then
            self.OnMessage(msg)
        end
    end
    kcp.OnError = function(err)
        if self.OnError then
            self.OnError(err)
        end
    end

    kcp.OnData = function(data)
        reader.Read(data)
    end

    kcp.OnOpen = function()
        if self.OnOpen then
            self.OnOpen()
        end
    end

    function self.Release()
        Looper.RemoveUpdate(self.Update)
        CS.UnityEngine.GameObject.Destroy(go)
    end
    function self.Update()

    end

    function self.Connect()
        kcp:Connect(address, port)
    end

    function self.Send( data )
        reader.Write(data, function(bin)
            kcp:Send(bin)
        end)
    end

    Looper.AddUpdate(self.Update)
    return self
end