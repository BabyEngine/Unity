EventManager = {}
local events = {}
local id = 1

-- @luadoc 添加监听器
-- @params target  any      触发事件时, 传递的首个参数
-- @params event   string   事件名称
-- @params handler function 回调
-- @return int 事件索引
function EventManager.AddListener( target, event, handler )
    if not event or type(event) ~= 'string' then
        print('event type error type should be string(' .. type(event) .. ')')
    end
    if not handler or type(handler) ~= 'function' then
        print('handler type error type should be function(' .. type(handler) .. ')')
    end

    if not events[event] then
        local evt = {}
        evt.observers = {}
        evt.count = 0
        function evt.Dispatch( ... )
            for k,v in pairs(evt.observers) do
                v.handler(v.target, ...)
            end
        end
        function evt.AddListener( target, handler )
            local obj = {
                target  = target,
                handler = handler
            }
            local ref = id
            evt.observers[ref] = obj
            evt.count = evt.count + 1
            id = id + 1
            return ref
        end
        function evt.RemoveListener(ref)
            if evt.observers[ref] then
                evt.observers[ref] = nil
                evt.count = evt.count - 1
            end
            if evt.count == 0 then
                events[event] = nil
            end
        end
        events[event] = evt
    end
    return events[event].AddListener(target, handler)
end

-- @luadoc 移除监听器
-- @params event string 事件名称
-- @params ref   int    索引
function EventManager.RemoveListener(event, ref)
    if not events[event] then
        print('no such event:', event)
        return
    end
    events[event].RemoveListener(ref)
end

-- @luadoc 触发事件
-- @params event string 事件名称
-- @params ...   args   参数
function EventManager.Dispatch(event, ... )
    if type(event) ~= 'string' then
        print('Dispatch Event Args Error(' .. type(event) .. ')')
    end
    if events[event] then
        events[event].Dispatch(...)
    else
        print('no such event:' .. event)
    end
end