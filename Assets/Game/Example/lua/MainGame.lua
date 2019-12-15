local m = {}

function m.start( ... )
    local button = CS.UnityEngine.GameObject.Find('Canvas/Button'):GetComponent(typeof(CS.UnityEngine.UI.Button))
    button.onClick:AddListener(function ( )
        print('click me')
        m.changeImage()
    end)

    print(ResourceManager)
    m.image = CS.UnityEngine.GameObject.Find('Canvas/Image'):GetComponent(typeof(CS.UnityEngine.UI.Image))

end

function m.changeImage()
    -- ResourceManager:LoadSprite('Test/button', function(sprite)
    --     m.image.sprite = sprite
    -- end)

    ResourceManager:LoadObject('Game/Example/Images/button', function( obj )
        m.image.sprite = obj:ToSprite()
    end)
end

m.start()
