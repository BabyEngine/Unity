BattlePanel = {}
local gameObject
local transform
function BattlePanel.Show( cb )
    if not transform then
        gameObject = LuaUtils.Find(nil, 'Canvas/Panels/BattlePanel')
        transform  = gameObject.transform
        BattlePanel.Show(cb)
    else
        BattlePanel.Init()
        if cb then
            cb()
        end
    end
end
function BattlePanel.Init()
    LuaUtils.UI.BindClick(transform, 'BattleZone/StartBattle', BattlePanel.OnClicked_StartBattle)
    -- DEBUG
    LuaUtils.UI.BindClick(transform, 'BattleZone/HotZone/1/Actor/Image', BattlePanel.OnClicked_StartBattle)
end

function BattlePanel.OnClicked_StartBattle()
    -- print('开始战斗')
    GameMsg.SendActionStartBattle(function(resp, err)
        if err ~= nil then
            print(err)
        end
        print('开始战斗', table.tostring(resp))
    end)
end

function BattlePanel.OnClicked_StartBattle()
    local tmp = LuaUtils.UI.FindSlider(transform, 'BattleZone/HotZone/1/Actor/Slider')
end