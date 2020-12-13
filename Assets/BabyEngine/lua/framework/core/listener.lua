-- @luadoc 监听器
function NewListener()
    local self = {}
    local callbacks = {}
    function self.Add( cb )
        table.insert(callbacks, cb)
    end

    function self.Remove( cb )
        for i,v in ipairs(callbacks) do
            if cb == v then
                table.remove(callbacks, i)
                return
            end
        end
    end

    function self.Call( ... )
        for i,v in ipairs(callbacks) do
            v(...)
        end
    end
    return self
end
