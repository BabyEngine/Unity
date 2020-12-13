local util = require 'xlua.util'

Coroutine = {}
function Coroutine.Start( ... )
    return LooperManager:StartCoroutine(util.cs_generator(...))
end

function Coroutine.Yield( sec )
    if sec == nil then
        coroutine.yield()
    elseif type(sec) == 'number' then
        coroutine.yield(CS.UnityEngine.WaitForSeconds(sec))
    end
end

function Coroutine.Stop( co )
    LooperManager:StopCoroutine(co)
end
