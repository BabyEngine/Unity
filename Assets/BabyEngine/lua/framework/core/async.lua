-- MIT License
-- Blake@github.com/DGHeroin/async.lua

local async = {}
local unpack = unpack or table.unpack

function async.waterfall(tasks, resultCb)
    local nextArg = {}
    local next
    local error

    next = function()
        if #tasks == 0 then
            if resultCb then
                resultCb(error, unpack(nextArg))
            end
            resultCb = nil
            return
        end
        if error then
            tasks = {} -- 清空序列
            resultCb(error, unpack(nextArg))
            return
        end
        local err = nil
        local v = table.remove(tasks, 1)
        v(function(err, ...)
            local arg = {...}
            nextArg = arg
            if err then
                error = err
            end
            next()
        end, unpack(nextArg))
    end
    next()
end

return async