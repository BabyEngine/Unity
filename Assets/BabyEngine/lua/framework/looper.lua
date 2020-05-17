LooperManager = LooperManager or {}
Time = Time or {time=0}

Looper = {}
local self = Looper
self.UpdateList          = {}
self.OnGUIFuncList       = {}
self.FixedUpdateFuncList = {}
self.LateUpdateFuncList  = {}

local delayCallbacks = {}

local function onUpdate()
    local keep ={}
    for i,v in ipairs(delayCallbacks) do
        if Time.time > v.time then
            v.cb()
            if v.r == -1 then
                table.insert(keep, v)
            elseif v.r > 1 then
                v.r = v.r - 1
                table.insert(keep, v)
            end
        else
            table.insert(keep, v)
        end
    end
    delayCallbacks = keep
end


-- @luadoc 在 Update 中延迟调用
-- @params delay double   延迟秒数量
-- @params cb    function 回调函数
-- @params r     int      重复次数
function self.AfterFunc(delay, cb, r)
    if type(cb) ~= 'function' then return end
    delay = delay
    r = r or 1
    if delay < 0 then delay = 0 end
    table.insert(delayCallbacks, {cb=cb, time = Time.time + delay, r = r})
end

-- @luadoc 增加 Update 回调
-- @params cb function 回调函数
function self.AddUpdate(cb)
    self.UpdateList[cb] = cb
end
-- @luadoc 删除 Update 回调
-- @params cb function 回调函数
function self.RemoveUpdate(cb)
    self.UpdateList[cb] = nil
end
-- @luadoc Update 回调执行器
LooperManager.UpdateFunc = function()
    onUpdate()
    for k,v in pairs(self.UpdateList) do
        if type(v) == 'function' then
            v()
        end
    end
end
-- @luadoc 增加 OnGUI 回调
-- @params cb function 回调函数
function self.AddOnGUI(cb)
    self.OnGUIFuncList[cb] = cb
end
-- @luadoc 删除 OnGUI 回调
-- @params cb function 回调函数
function self.RemoveOnGUI(cb)
    self.OnGUIFuncList[cb] = nil
end
-- @luadoc OnGUI 回调执行器
LooperManager.OnGUIFunc = function()
    for k,v in pairs(self.OnGUIFuncList) do
        if type(v) == 'function' then
            v()
        end
    end
end
-- @luadoc 增加 FixedUpdate 回调
-- @params cb function 回调函数
function self.AddFixedUpdate(cb)
    self.FixedUpdateFuncList[cb] = cb
end
-- @luadoc 删除 FixedUpdate 回调
-- @params cb function 回调函数
function self.RemoveFixedUpdate(cb)
    self.FixedUpdateFuncList[cb] = nil
end
-- @luadoc FixedUpdate 回调执行器
LooperManager.FixedUpdateFunc = function()
    for k,v in pairs(self.FixedUpdateFuncList) do
        if type(v) == 'function' then
            v()
        end
    end
end
-- @luadoc 增加 LateUpdateFunc 回调
-- @params cb function 回调函数
function self.AddLateUpdate(cb)
    self.LateUpdateFuncList[cb] = cb
end
-- @luadoc 删除 LateUpdateFunc 回调
-- @params cb function 回调函数
function self.RemoveLateUpdate(cb)
    self.LateUpdateFuncList[cb] = nil
end
-- @luadoc FixedUpdate 回调执行器
LooperManager.LateUpdateFunc = function()
    for k,v in pairs(self.LateUpdateFuncList) do
        if type(v) == 'function' then
            v()
        end
    end
end
