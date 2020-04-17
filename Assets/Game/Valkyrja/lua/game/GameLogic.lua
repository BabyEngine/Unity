GameLogic = {}

function GameLogic.StartGame()
    GameLogic.Init()
    BattlePanel.Show()
    NetMgr.Connect()
end

function GameLogic.Init()
    GameLogic.debugStausText = LuaUtils.UI.FindText(nil, 'Canvas/DebugStatus/Text')
    Looper.AddUpdate(GameLogic.OnUpdate)
end

function GameLogic.OnUpdate( )
    local text = ''
    text = string.format('网络状态:%d', NetMgr.conn.state)
    GameLogic.debugStausText.text = text
end

require('game.ui.BattlePanel')