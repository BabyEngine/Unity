local CSKCPClient = CS.KCPClient
function KCPClient(url)
    local self = {}

    local client

    function self.Connect(addr, port)
        client:Connect(addr, port)
    end
    local function OnOpen()
        print('open...')
        if self.OnOpen then self.OnOpen() end
    end
    local function OnData(...)
        if self.OnData then self.OnData(...) end
    end
    local function OnError(ex)
        if self.OnError then self.OnError(ex) end
    end
    local function onUpdate()
        client:Update()
    end
    function self.Release()
        Looper.RemoveUpdate(onUpdate)
    end

    function self.Send( bytes )
        client:Send(bytes)
    end

    client = CSKCPClient()
    client.OnOpen = OnOpen
    client.OnData = OnData
    client.OnError = OnError

    Looper.AddUpdate(onUpdate)

    return self
end
