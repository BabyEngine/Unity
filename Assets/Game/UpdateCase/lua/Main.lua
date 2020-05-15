print("lua start")

local image = LuaUtils.UI.FindImage(nil, 'GameCanvas/GamePlayPanel/Image')

LuaUtils.UI.FindButton(nil, 'GameCanvas/GamePlayPanel/Button', function ( )
    if image then
        CS.BabyEngine.ResourceManager.Get():LoadSprite('Game/UpdateCase/res/red_dot', function(tx)
            image.sprite = tx
        end)
    end
end)

CS.BabyEngine.ResourceManager.Get():LoadObject('Game/UpdateCase/res/avatarImage', function(obj)
    local parent = LuaUtils.UI.FindImage(nil, 'GameCanvas/GamePlayPanel')
    if not obj then return end
    CS.UnityEngine.Object.Instantiate(obj).transform:SetParent(parent.transform, false)
end)