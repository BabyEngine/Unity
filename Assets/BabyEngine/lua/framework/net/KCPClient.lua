function KCPClient()
    local self = {}

    local client

    function self.Connect(addr, port)
        client:Connect(addr, port)
    end
    local function OnOpen()
        if self.OnOpen then self.OnOpen() end
    end
    local function OnData(...)
        if self.OnData then 
            local ok, ret = pcall(self.OnData, ...)
            if not ok then
                print(ret)
            end
        end
    end
    local function OnError(ex)
        if self.OnError then self.OnError(ex) end
    end
    function self.Release()
        client:Close()
    end

    function self.Send( bytes )
        client:Send(bytes)
    end
    function self.Update( ... )
        client:Update()
    end
    
    client = NetworkManager:AddClient('kcp')
    print('kcp', kcp)
    client.OnOpenFunc  = OnOpen
    client.OnDataFunc  = OnData
    client.OnErrorFunc = OnError

    -- client:RunInThread(LooperManager)

    return self
end
