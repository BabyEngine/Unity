local _DefaultEventManager
function DefaultEventManager(set)
    if set then
        _DefaultEventManager = set
    end
    if _DefaultEventManager == nil and set == nil then
        _DefaultEventManager = NewEventManager()
    end
    return _DefaultEventManager
end
function NewEventManager()
    local self = {}
    local events = {}
    local id = 1

    -- @luadoc 添加监听器
    -- @params target  any      触发事件时, 传递的首个参数
    -- @params event   string   事件名称
    -- @params handler function 回调
    -- @return int 事件索引
    function self.AddListener( target, event, handler )
        local btInfo = debug.traceback()
        if not event or type(event) ~= 'string' then
            print('event type error type should be string(' .. type(event) .. ')', debug.traceback())
            return
        end
        if not handler or type(handler) ~= 'function' then
            print('handler type error type should be function(' .. type(handler) .. ')', debug.traceback())
            return
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
            function evt.AddListener( target2, handler2 )
                local obj = {
                    target  = target2,
                    handler = handler2
                }
                local key
                if target2 ~= nil and handler2 ~= nil then
                    key = tostring(target2) .. tostring(handler2)
                else
                    key = tostring(handler2)
                end
                if evt.observers[key] ~= nil then
                    print('handler 重复', target2, event, handler2, debug.traceback())
                    return
                end
                evt.observers[key] = obj
                evt.count = evt.count + 1
            end
            function evt.RemoveListener(target2, handler2)
                local key
                if target2 ~= nil and handler2 ~= nil then
                    key = tostring(target2) .. tostring(handler2)
                else
                    key = tostring(handler2)
                end
                if evt.observers[key] then
                    evt.observers[key] = nil
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
    -- @params event   string   事件名称
    -- @params handler function 索引
    function self.RemoveListener(target, event, handler)
        if not events[event] then
            print('RemoveListener no such event:', event, debug.traceback())
            return
        end
        events[event].RemoveListener(target, handler)
    end

    -- @luadoc 触发事件
    -- @params event string 事件名称
    -- @params ...   args   参数
    function self.Dispatch(event, ... )
        if type(event) ~= 'string' then
            print('Dispatch Event Args Error(' .. type(event) .. ')')
        end
        if events[event] then
            events[event].Dispatch(...)
        else
            -- print('Dispatch no such event:' .. tostring(event), debug.traceback())
        end
    end
    return self
end
