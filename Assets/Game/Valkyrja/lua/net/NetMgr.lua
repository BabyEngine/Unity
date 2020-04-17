

NetMgr = {}
function NetMgr.Connect()
    local client = net.NewKCPBinaryClient(AppConf.ServerAddress, AppConf.ServerPort)
    client.OnOpen = function (serverName)
        print('服务器连接成功:', serverName)
        GameMsg.client = client
        GameMsg.SendActionLogin(function(rs, err)
            if err ~= nil then
                print('login error:', err)
                return
            end
            print('login resp:', table.tostring(rs))
        end)
    end
    client.OnError = function (err)
        print('发生错误', err)
    end
    client.OnClose = function (cli)
        print('连接关闭')
    end
    client.OnData = function ( msg )
        -- print('收到消息', msg)
        local name, obj = GameMsg.OnMessage(msg)
        obj = obj or {}
        print('===>', name, table.tostring(obj))
    end

    client.Connect()

    NetMgr.conn = client
end