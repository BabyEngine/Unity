print("lua start")

local image = LuaUtils.UI.FindImage(nil, 'Canvas/GamePlayPanel/Image')

LuaUtils.UI.FindButton(nil, 'Canvas/GamePlayPanel/Button', function ( )
    print('click...')
    if image then
        CS.BabyEngine.ResourceManager.Get():LoadSprite('Game/UpdateCase/res/red_dot', function(tx)
            print('tx==>', tx)
            image.sprite = tx
        end)
    end
end)

