-- @luadoc 解析UI
-- @param transform UnityTransform
-- @param t table   从 transform 开始计算的路径表 例如 { { t=1, p='Image_icon' }, { t=2, p='Button_Unlock' }, { t=3, p='Text_Name' }, }
function ParseUI( tra, t )
    local self = {}
    local imageMap  = {}
    local textMap   = {}
    local buttonMap = {}
    local buttonHandler = {}
    local sliderMap = {}
    local transform = nil
    local setupHandler
    local function setupImage(obj)
        local path = obj.p or ''
        obj.go = LuaUtils.UI.FindImage(transform, path)
        if obj.go then
            imageMap[path] = obj.go
        end
    end
    local function onClick( obj )
        if not obj then return end
        if buttonHandler and type(buttonHandler[obj.p]) == 'function' then
            buttonHandler[obj.p]()
        end
    end
    function self.BindButtonHandler( hander )
        buttonHandler = hander
    end
    local function setupButton(obj)
        local path = obj.p or ''
        obj.go = LuaUtils.UI.BindClick(transform, path, onClick, nil, obj)
        if obj.go then
            buttonMap[path] = obj.go
        end
    end

    local function setupText(obj)
        local path = obj.p or ''
        obj.go = LuaUtils.UI.FindText(transform, path)
        if obj.go then
            textMap[path] = obj.go
        end
    end
    local function setupSlider(obj)
        local path = obj.p or ''
        obj.go = LuaUtils.UI.FindSlider(transform, path)
        if obj.go then
            sliderMap[path] = obj.go
        end
    end

    function self.InitParser(tra, tbl)
        if tra == nil and tbl == nil then return end
        transform = tra
        setupHandler = {
            [1] = setupImage,
            [2] = setupButton,
            [3] = setupText,
            [4] = setupSlider,
        }
        local t = tbl or {}
        for k,v in pairs(t) do
            local t = v.t or -1
            if setupHandler[t] then
                setupHandler[t](v)
            end
        end
    end

    function self.GetGameObject( path )
        local tra = LuaUtils.Find(transform, path)
        if tra then return tra.gameObject end
    end

    function self.UIRemapping( target, mapping )
        for k,v in pairs(mapping) do
            target[k] = nil --清空
            local obj
            obj = textMap[v]
            if not target[k] and obj then target[k] = obj end

            obj = imageMap[v]
            if not target[k] and obj then target[k] = obj end

            obj = sliderMap[v]
            if not target[k] and obj then target[k] = obj end

            obj = buttonMap[v]
            if not target[k] and obj then target[k] = obj end

            if not target[k] then
                target[k] = self.GetGameObject(v)
            end
        end
    end
    self.InitParser(tra, t)
    return self
end
