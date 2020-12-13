local CSLogCapture     = CS.LogCapture
local GameObject       = CS.UnityEngine.GameObject
local Object           = CS.UnityEngine.Object
local Application      = CS.UnityEngine.Application
local UnityWebRequest  = CS.UnityEngine.Networking.UnityWebRequest
local UploadHandlerRaw = CS.UnityEngine.Networking.UploadHandlerRaw
local SystemInfo       = CS.UnityEngine.SystemInfo
local PlayerPrefs      = CS.UnityEngine.PlayerPrefs

local function buildQCloudSCFPostData(logIndex, condition, stackTrace, logType)
    local url = 'https://service-8ctjrppd-1256176692.cd.apigw.tencentcs.com/release/log'
    local appToken = 'pet'
    local appID    = 'pet_secrets'

    local info = {
        appToken = appToken,
        appID    = appID,
        platform = Application.platform:ToString(),
        deviceId = SystemInfo.deviceUniqueIdentifier,
        playerId = PlayerPrefs.GetString('__player_id__'),
        i = logIndex,
        c = tostring(condition),
        s = tostring(stackTrace),
        t = tostring(logType)
    }

    return url, info
end


function LogCapture( captureType )
    local self = {}
    local gameObject
    local logIndex = 0
    
    
    local errorCount = 0
    function self.Init( cb )
        gameObject = GameObject()
        local ref = gameObject:AddComponent(typeof(CSLogCapture))
        if ref then
            ref.logHandler = self.logHandler
        end
        Object.DontDestroyOnLoad(gameObject)
        if cb then cb() end
    end
    
    function self.logHandler( condition, stackTrace, logType )
        if not self.isServerOk() then 
            return
        end
        logIndex = logIndex + 1
        
        local url, info = buildQCloudSCFPostData(logIndex, condition, stackTrace, logType)
        local args = json.encode(info)
        self.HTTPPost(url, args, function(req)
            if req.isNetworkError or req.isHttpError then
                errorCount = errorCount + 1
                return
            end
            errorCount = 0
        end)
    end
    function self.isServerOk()
        return errorCount < 10
    end

    function self.HTTPPost( url, args, cb )
        local request = UnityWebRequest.Post(url, '')
        local uh = UploadHandlerRaw( args )
        request.uploadHandler = uh
        request:SetRequestHeader("Content-Type", "application/json")
        NetworkManager:RunWebRequest(request, function()
            cb(request)
        end)
        return request
    end

    function self.Release()
        Destroy(gameObject)
        gameObject = nil
    end

    return self
end
