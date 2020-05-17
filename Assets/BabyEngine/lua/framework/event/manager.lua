EventManager = {}
local events = {}

function EventManager.AddListener( target, event, handler )
    if not event or type(event) ~= 'string' then
        error('event type error type should be string(' .. type(event) .. ')')
    end
    if not handler or type(handler) ~= 'function' then
        error('handler type error type should be function(' .. type(handler) .. ')')
    end

    if not events[event] then
        local evt = {}
        evt.observers = {}
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
            evt.observers[obj] = obj
        end
        function evt.RemoveListener(target, handler)
            for k,v in pairs(observers) do
                if v.target == target and v.handler = handler then
                    observers[k] = nil
                    return
                end
            end
        end
        events[event] = evt
    end
    events[event].AddListener(target, handler)
end

function EventManager.RemoveListener(target, event, handler)
    if event == nil then
        return
    end
    if not events[event] then
        return
    end

    events[event].RemoveListener(target, handler)
end

function EventManager.Dispatch(event, ... )
    if type(event) ~= 'string' then
        error('Dispatch Event Args Error(' .. type(event) .. ')')
    end
    if events[event] then
        events[event].Dispatch(...)
    else
        error('no such event:' .. event)
    end
end