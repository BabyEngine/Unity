LuaUtils = LuaUtils or {}

LuaUtils.UI   = {}
LuaUtils.Game = {}
local Utility = CS.BabyEngine.Utility
function IsNull( obj )
    return Utility.IsNull(obj)
end

-- @luadoc 查找节点
-- @params transform Transform the transform
-- @params child     function  callback
function LuaUtils.Find(transform, name)
    if name == nil or name == '' then
        return transform
    end
    local tra
    if transform then
        transform = transform.transform
        tra = transform:Find(name)
    else
        -- return CS.UnityEngine.GameObject.Find(name)
        tra = Utility.FindGameObject(name)
    end
    if tra then
        return tra.transform
    end
end

-- @luadoc 获取 Button 组件
-- @params transform Transform the transform
-- @params transform string    name of child
-- @params child     function  callback
function LuaUtils.UI.FindButton(transform, name, cb)
    local node = LuaUtils.Find(transform, name)
    if not node then return end
    local button = node:GetComponent(typeof(CS.UnityEngine.UI.Button))
    if button then
        button.onClick:AddListener(cb)
    end
    return button
end

-- @luadoc 获取 长按 组件
-- @params transform Transform the transform
-- @params transform string    name of child
-- @params child     function  callback
function LuaUtils.UI.FindLongPressButton(transform, name, cb)
    local tra = LuaUtils.Find(transform, name)
    if not tra then return nil end
    local self = {}
    local onLongPress = function()
        if self.onLongPress then self.onLongPress() end
    end
    local onLongPressPrepare = function()
        if self.onLongPressPrepare then self.onLongPressPrepare() end
    end
    local onShortPress = function()
        if self.onShortPress then self.onShortPress() end
    end
    local onPressLeave = function()
        if self.onPressLeave then self.onPressLeave() end
    end

    local comp = tra.gameObject:GetComponent(typeof(CS.LongPressEventTrigger))
    if not comp then
        comp = tra.gameObject:AddComponent(typeof(CS.LongPressEventTrigger))
    end
    comp.onLongPress:AddListener(onLongPress)
    comp.onLongPressPrepare:AddListener(onLongPressPrepare)
    comp.onShortPress:AddListener(onShortPress)
    comp.onPressLeave:AddListener(onPressLeave)
    function self.GetProgress()
        return comp.Progress
    end
    return self
end


-- @luadoc 获取 Text 组件
-- @params transform Transform the transform
-- @params transform string    name of child
function LuaUtils.UI.FindText(transform, name)
    local node = LuaUtils.Find(transform, name)
    if not node then return end
    return node:GetComponent(typeof(CS.UnityEngine.UI.Text))
end

-- @luadoc 获取 Text 组件
-- @params transform Transform the transform
-- @params transform string    name of child
function LuaUtils.UI.FindTextMesh(transform, name)
    local node = LuaUtils.Find(transform, name)
    if not node then return end
    return node:GetComponent(typeof(CS.TMPro.TextMeshProUGUI))
end

-- @luadoc 获取 Image 组件
-- @params transform Transform the transform
-- @params transform string    name of child
function LuaUtils.UI.FindImage(transform, name)
    local node = LuaUtils.Find(transform, name)
    if not node then return end
    return node:GetComponent(typeof(CS.UnityEngine.UI.Image))
end

-- @luadoc 获取 RawImage 组件
-- @params transform Transform the transform
-- @params transform string    name of child
function LuaUtils.UI.FindRawImage(transform, name)
    local node = LuaUtils.Find(transform, name)
    if not node then return end
    return node:GetComponent(typeof(CS.UnityEngine.UI.RawImage))
end

-- @luadoc 获取 Toggle 组件
-- @params transform Transform the transform
-- @params transform string    name of child
function LuaUtils.UI.FindToggle(transform, name, cb, defaultValue, ...)
    local node = LuaUtils.Find(transform, name)
    if not node then return end
    local comp = node:GetComponent(typeof(CS.UnityEngine.UI.Toggle))
    if not comp then return end
    local args = {...}
    comp.isOn = defaultValue == true
    comp.onValueChanged:AddListener(function(val)
            cb(val, table.unpack(args))
    end)

end

-- @luadoc 获取 Slider 组件
-- @params transform Transform the transform
-- @params name      string    name of child
-- @params cb        funcetion callback
function LuaUtils.UI.FindSlider(transform, name, cb, ...)
    local node = LuaUtils.Find(transform, name)
    if not node then return end
    local slider = node:GetComponent(typeof(CS.UnityEngine.UI.Slider))
    if slider and cb then
        local args = {...}
        slider.onValueChanged:AddListener(function(val)
            cb(val, table.unpack(args))
        end)
    end
    return slider
end

-- @luadoc 获取 InputField 组件
-- @params transform Transform the transform
-- @params transform string    name of child
function LuaUtils.UI.FindInputField(transform, name)
    local node = LuaUtils.Find(transform, name)
    if not node then return end
    return node:GetComponent(typeof(CS.UnityEngine.UI.InputField))
end

-- @luadoc 获取 Dropdown 组件
-- @params transform Transform the transform
-- @params transform string    name of child
function LuaUtils.UI.FindDropdown(transform, name, list, cb)
    local node = LuaUtils.Find(transform, name)
    if not node then return end
    local comp = node:GetComponent(typeof(CS.UnityEngine.UI.Dropdown))
    if not comp then return end
    if list then
        comp.options:Clear()
        for i,v in ipairs(list) do
            local data = CS.UnityEngine.UI.Dropdown.OptionData()
            data.text = tostring(v)
            comp.options:Add(data)
        end
    end
    if cb then
        comp.onValueChanged:AddListener(cb)
    end
    return comp
end

-- @luadoc 查找节点
-- @params transform Transform the transform
-- @params child     function  callback
function LuaUtils.TransformForeach(transform, cb)
    local count = transform.childCount - 1
    for i=1, count do
        cb(transform:GetChild(i-1))
    end
end

local clickHijack
function LuaUtils.UI.GetClickHijack()
    return clickHijack
end
function LuaUtils.UI.BindClickHijack(cb)
    -- print('BindClickHijack old:', clickHijack, 'new:', cb, debug.traceback())
    clickHijack = cb
end
UtilsUILoadButtonDownAnimFunc = nil
UtilsUILoadButtonUpAnimFunc = nil
DefaultButtonClickedAudio = nil
-- @luadoc 查找
-- @params transform Transform the transform
-- @params name      string name of child
-- @params child     function  callback
function LuaUtils.UI.BindClick(transform, name, cb, opts, ... )
    opts = opts or {}

    local tra = LuaUtils.Find(transform, name)
    if not tra then return end
    local handler = tra:GetComponent(typeof(CS.UIEventHandler))
    if not handler then
        handler = tra.gameObject:AddComponent(typeof(CS.UIEventHandler))
    end
    local button = tra.gameObject:GetComponent(typeof(CS.UnityEngine.UI.Button))
    if button then
        Destroy(button)
    end
    local args = {...}
    -- -1 左键
    -- -2 右键
    handler.onPointerClick = function ( eventData )
        local clickedAudio = opts.audio or DefaultButtonClickedAudio
        if opts.no_audio then clickedAudio = nil end
        if clickedAudio then
            AudioManager.PlaySFX(clickedAudio)
        end
        cb(table.unpack(args))
        if clickHijack then
            clickHijack()
        end
    end
    -- 动画
    local withAnim = true
    if opts.anim ~= nil then
        withAnim = opts.anim
    end

    local tween = nil
    local dt = 0.1
    local scale = 0.95
    local origin = tra.transform.localScale
    handler.onPointerDown = function ( eventData )
        if withAnim then
            if UtilsUILoadButtonDownAnimFunc then
                local anim = tra.gameObject:GetComponent(typeof(CS.UnityEngine.Animation))
                if not anim or anim:IsNull() then
                    anim = tra.gameObject:AddComponent(typeof(CS.UnityEngine.Animation))
                end
                if not anim then return end
                UtilsUILoadButtonDownAnimFunc(function(obj)
                    if anim and obj then
                        anim.clip = NewObject(obj)
                        anim:AddClip(obj, 'down')
                        anim:Rewind()
                        anim:Play('down')
                    end
                end)
            else
                tween = tra.transform:DOScale(scale, dt)
                tween:OnComplete(function()
                    tween = nil
                end)
            end
        end
    end
    handler.onPointerUp = function ( eventData )
        if withAnim then
            if UtilsUILoadButtonUpAnimFunc then
                local anim = tra.gameObject:GetComponent(typeof(CS.UnityEngine.Animation))
                if not anim or anim:IsNull() then
                    anim = tra.gameObject:AddComponent(typeof(CS.UnityEngine.Animation))
                end
                if not anim then return end
                UtilsUILoadButtonUpAnimFunc(function(obj)
                    if anim and obj then
                        anim.clip = NewObject(obj)
                        anim:AddClip(obj, 'up')
                        anim:Rewind()
                        anim:Play('up')
                    end
                end)
            else
                if tween then
                    tween:Kill()
                end
                if not tra.gameObject:IsActive() then
                else
                    tra.transform:DOScale(1, dt)
                end
            end

        end
    end
    -- 音效

    return tra.gameObject, handler
end

-- @luadoc 获取 AudioSource 组件
-- @params transform Transform the transform
-- @params transform string    name of child
function LuaUtils.Game.FindAudioSource(transform, name)
    local node = LuaUtils.Find(transform, name)
    if not node then return end
    return node:GetComponent(typeof(CS.UnityEngine.AudioSource))
end

-- @luadoc 获取 Animator 组件
-- @params transform Transform the transform
-- @params transform string    name of child
function LuaUtils.Game.FindAnimator(transform, name)
    local node = LuaUtils.Find(transform, name)
    if not node then return end
    return node:GetComponent(typeof(CS.UnityEngine.Animator))
end

-- @luadoc 获取 Animation 组件
-- @params transform Transform the transform
-- @params transform string    name of child
function LuaUtils.Game.FindAnimation(transform, name)
    local node = LuaUtils.Find(transform, name)
    if not node then return end
    return node:GetComponent(typeof(CS.UnityEngine.Animation))
end

-- @luadoc 获取 Light 组件
-- @params transform Transform the transform
-- @params transform string    name of child
function LuaUtils.Game.FindLight(transform, name)
    local node = LuaUtils.Find(transform, name)
    if not node then return end
    return node:GetComponent(typeof(CS.UnityEngine.Light))
end

--@luadoc 震动
function LuaUtils.Vibrate()
    if CS.UnityEngine.Application.isMobilePlatform then
        CS.UnityEngine.Handheld.Vibrate()
    end
end

function LuaUtils.SetActive( tra, path, b)
    if not tra then return end
    if type(path) == 'string' and type(b) == 'boolean' then
        local go = LuaUtils.Find(tra.transform, path)
        if go then
            go.gameObject:SetActive(b == true)
        end
    end
    if type(path) == 'boolean' then
        b = path
        tra.gameObject:SetActive(b == true)
    end
end

function LuaUtils.SetActives( objs, b)
    if type(objs) ~= 'table' then return end
    for i,v in ipairs(objs) do
        v.gameObject:SetActive(b == true)
    end
end

function LuaUtils.Destroy( objs)
    if type(objs) ~= 'table' then return end
    for i,v in ipairs(objs) do
        Destroy(v.gameObject)
    end
end

function LuaUtils.FindCamera( tra, path )
    local tra = LuaUtils.Find(tra, path)
    if tra then
        return tra.gameObject:GetComponent(typeof(CS.UnityEngine.Camera))
    end
end

--@luadoc 注入 OnUpdate
function MakeUpdateList( self )
    local updateList = {}
    function self.AddUpdate( obj )
        table.insert(updateList, obj)
    end

    function self.RemoveUpdate( obj )
        table.remove(updateList, obj)
    end

    function self.OnUpdate()
        for i,v in ipairs( updateList ) do
            v.OnUpdate()
        end
    end
end

--@luadoc 注入 OnFixedUpdate
function MakeFixedUpdateList( self )
    local updateList = {}
    function self.AddFixedUpdate( obj )
        table.insert(updateList, obj)
    end

    function self.RemoveFixedUpdate( obj )
        table.remove(updateList, obj)
    end

    function self.OnFixedUpdate()
        for i,v in ipairs( updateList ) do
            v.OnFixedUpdate()
        end
    end
end

--@luadoc 注入 超时检查
function MakeTimeout( self, period, cb )
    local lastTime = -period
    local dirty = true
    local lastDuration = 0
    function self.TimeoutPeriod()
        return period
    end
    function self.IsTimeout()
        if Time.time - lastTime >= period then
            lastTime = Time.time
            dirty = true
            return true
        end
    end
    function self.TimeoutDuration()
        if not dirty then return lastDuration end
        local t = period - (Time.time - lastTime)
        if t < 0 then
            t = 0
            dirty = false
        end
        if t > period then t = period end
        lastDuration = t
        return t
    end
    if cb then cb() end
end

function format_int(number)
  local i, j, minus, int, fraction = tostring(number):find('([-]?)(%d+)([.]?%d*)')
  -- reverse the int-string and append a comma to all blocks of 3 digits
  int = int:reverse():gsub("(%d%d%d)", "%1,")
  -- reverse the int-string back remove an optional comma and put the
  -- optional minus and fractional part back
  return minus .. int:reverse():gsub("^,", "") .. fraction
end