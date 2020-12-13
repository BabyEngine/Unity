function NewTimePoint(days, hours, minutes, seconds, milliseconds)
    local self = {}
    local Stopwatch = CS.System.Diagnostics.Stopwatch
    local TimeSpan  = CS.System.TimeSpan

    -- 时间统计器
    local timeSpanCount
    if days ~= nil and hours ~= nil and minutes ~= nil and seconds  ~= nil and milliseconds  ~= nil then
        timeSpanCount = CS.System.TimeSpan(days, hours, minutes, seconds, milliseconds)
    else
        timeSpanCount = CS.System.TimeSpan()
    end

    local stopWatch = Stopwatch()
    local lastElapsed = {0, 0, 0, 0, 0}
    local lastElapsedDirty = true
    local lastElapsedStr
    function self.ElapsedTime()
        stopWatch:Stop()
        local ts = stopWatch.Elapsed
        timeSpanCount:Add(ts)
        lastElapsedDirty = true
        return ts.Days, ts.Hours, ts.Minutes, 
                ts.Seconds, ts.Milliseconds
        -- return string.format('%d:%d:%d.%d', ts.Hours, ts.Minutes, 
        --         ts.Seconds, ts.Milliseconds)
    end
    function self.ElapsedTimeString()
        if not lastElapsedDirty then return lastElapsedStr end
        local days         = lastElapsed[1]
        local hours        = lastElapsed[2]
        local minutes      = lastElapsed[3]
        local seconds      = lastElapsed[4]
        local milliseconds = lastElapsed[5]
        local flag
        local rs = {}
        for i,v in ipairs(lastElapsed) do
            if v ~= 0 then
                flag = true
            end
            if flag then
                if v < 4 then
                    table.insert(tostring(v) .. ':')
                elseif v == 4 then
                    table.insert(tostring(v) .. '.')
                else
                    table.insert(tostring(v))
                end
            end
        end
        lastElapsedStr = table.concat(rs)
    end
    function self.Start()
        stopWatch:Start()
    end
    function self.TimeSpanCount()
        return timeSpanCount.Days, timeSpanCount.Hours, timeSpanCount.Minutes, 
                timeSpanCount.Seconds, timeSpanCount.Milliseconds
    end
    self.Start()
    return self
end
