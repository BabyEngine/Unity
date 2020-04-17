local pb = require "pb"
local protoc = require "protobuf/protoc"
require 'net.pb'
if not pb.type"GameMessage" then
    protoc:load(PBDefine)
end

GameMsg = {}
local ParseMap = {}

local function sendAction(actionName, obj, cb)
    local msgName = ParseMap[actionName]
    local data
    if msgName then
         data = pb.encode(msgName, obj)
    end
    cb = cb or function() end

    local m = {action=actionName, data=data}
    local bin = pb.encode('GameMessage', m)
    GameMsg.client.Request(bin, function(data, err)
        if err ~= nil then
            print('req error:', err)
            cb(nil, err)
            return
        end
        local obj = pb.decode('GameMessage', data)
        if not obj then
            cb(nil, 'Decode GameMessage Failed.')
            return
        end
        local actionName = obj.action
        local msgName = ParseMap[actionName]
        if not msgName then
            cb(nil, string.format('Decode (%s)Message Failed.', actionName))
            return
        end

        local rs = pb.decode(msgName, obj.data)
        cb(rs, nil)
    end)
end

function GameMsg.SendActionLogin(cb)
    local req = {
        token = string.format('%s:%s:%s',
            'guest',
            CS.UnityEngine.SystemInfo.deviceUniqueIdentifier,
            'guest'
            )
    }
    sendAction('req.login', req, cb)
end

function GameMsg.SendActionStartBattle( cb )
    local req = {}
    sendAction('req.battle.start', req, cb)
end

function GameMsg.OnMessage ( data )
    local obj = pb.decode('GameMessage', data)
    if not obj then return end
    local actionName = obj.action
    local msgName = ParseMap[actionName]
    if not msgName then return end

    local rs = pb.decode(msgName, obj.data)
    print(actionName, table.tostring(rs))
    return actionName, rs
end

ParseMap['req.login'] = 'RequestLoginMessage'
ParseMap['rsp.common'] = 'ResponseCommon'

--ParseMap['req.battle.start'] = 'ResponseCommon'