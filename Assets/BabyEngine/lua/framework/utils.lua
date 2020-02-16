LuaUtils = LuaUtils or {}

LuaUtils.UI = {}

-- @luadoc 查找节点
-- @params transform Transform the transform
-- @params child     function  callback
function LuaUtils.Find(transform, name)
    return transform:Find(name)
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

-- @luadoc 获取 Text 组件
-- @params transform Transform the transform
-- @params transform string    name of child
function LuaUtils.UI.FindText(transform, name)
    local node = LuaUtils.Find(transform, name)
    if not node then return end
    return node:GetComponent(typeof(CS.UnityEngine.UI.Text))
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
function LuaUtils.UI.FindToggle(transform, name)
    local node = LuaUtils.Find(transform, name)
    if not node then return end
    return node:GetComponent(typeof(CS.UnityEngine.UI.Toggle))
end

-- @luadoc 获取 Slider 组件
-- @params transform Transform the transform
-- @params transform string    name of child
function LuaUtils.UI.FindSlider(transform, name)
    local node = LuaUtils.Find(transform, name)
    if not node then return end
    return node:GetComponent(typeof(CS.UnityEngine.UI.Slider))
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