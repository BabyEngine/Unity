require('framework.core.types')
require('framework.core.funcs')
require('framework.core.utils')
require('framework.core.looper')
require('framework.core.pool')
require('framework.core.coroutine')
require('framework.core.listener')
require('framework.core.time')
async = require('framework.core.async')
require('framework.event.manager')
require('framework.audio.manager')
require('framework.ui.parser')
require('framework.ui.panel')
require('framework.ui.scrollview')
require('framework.net.LogCapture')
require('framework.net.SocketIO')
require('framework.net.KCPClient')
PRINT_BACKTRACE = true

local o_print = print
print = function(...)
    local args = {...}
    if PRINT_BACKTRACE then
        table.insert(args, '\n')
        table.insert(args, debug.traceback())
    end
    o_print(table.unpack(args))
end
printf = function(fmt, ...)
    if PRINT_BACKTRACE then
        local args = {'\n'}
        table.insert(args, debug.traceback())
        o_print(string.format(fmt, ...), table.unpack(args))
    else
        o_print(string.format(fmt, ...))
    end
end