AudioManager = AudioManager or {}
local channels = {}
local channelVolume = {}
local muted = {}
local pool
local transform
local gameObject = GameObject()
local function Init()
    transform = gameObject.transform
    AudioManager.gameObject = gameObject
    gameObject.name = 'AudioManager'
    GameObject.DontDestroyOnLoad(gameObject)

    local audioSourceGameObject = GameObject()
    audioSourceGameObject:AddComponent(typeof(CS.UnityEngine.AudioSource))
    audioSourceGameObject.transform:SetParent(gameObject.transform)
    audioSourceGameObject.name = 'AudioSourcePrefab'

    pool = NewObjectPool(audioSourceGameObject)
end

local function Save()
    -- TODO 保存
    print('触发保存')
end

local function Load( ... )
    -- TODO 加载
end
local lastModTime = 0
local isSaving
local function StartSaveTicker(b)
    if not b then
        lastModTime = Time.time
    end
    if isSaving then
        return
    end
    isSaving = true
    local checker
    checker = function()
        if Time.time - lastModTime < 0.2 then
            Looper.AfterFunc(0.1, checker)
            return
        end
        Save()
        isSaving = false
    end
    Looper.AfterFunc(0.1, checker)
end

local function GetVolume( channelName )
    channelVolume[channelName] = channelVolume[channelName] or 0.8
    return channelVolume[channelName]
end

local function SetVolume( channelName, val )
    channelVolume[channelName] = val
    StartSaveTicker()
    local ch = channels[channelName] or {}
    for k,v in pairs(ch) do
        v.SetVolume(val)
    end
end

local function GetMute( channelName )
    if muted[channelName] ~= nil then
        return muted[channelName]
    end
    return false
end

local function SetMute( channelName, b )
    muted[channelName] = b
    StartSaveTicker()
    local ch = channels[channelName] or {}
    for k,v in pairs(ch) do
        v.SetMute(b)
    end
end

local function Play(channelName, audioClipName, isLoop, _type)
    isLoop = isLoop == true
    ResourceManager:LoadAudioClip(audioClipName, function ( clip )
        if not clip then
            -- error('LoadAudioClip error:'.. audioClipName)
            return 
        end
        local o = {}
        local go = pool.Get()
        go.transform:SetParent(transform)
        go.name = audioClipName
        local audioSource = go:GetComponent(typeof(CS.UnityEngine.AudioSource))
        if not audioSource then return end
        audioSource.clip = clip
        audioSource.volume = GetVolume(channelName)
        audioSource.mute   = GetMute(channelName)
        audioSource.loop = isLoop
        -- TODO speed
        audioSource:Play()

        function o.SetVolume( v )
            if o.isRelease then return end
            v = v or audioSource.volume
            audioSource.volume = v
        end

        function o.Release()
            if o.isRelease then return end
            o.isRelease = true
            channels[channelName][go] = nil
            pool.Put(go)
        end
        function o.SetMute( b )
            if o.isRelease then return end
            audioSource.mute = b
        end

        channels[channelName] = channels[channelName] or {}

        if _type > 0 then -- 在这个频道里为独占
            for k,v in pairs(channels[channelName]) do
                v.Release()
            end
        end
        channels[channelName][go] = o
        if not isLoop then
            Looper.AfterFunc(clip.length, function() 
                o.Release()
            end)
        end
    end)
end

function AudioManager.PlayBGM( name )
    Play('bgm', name, true, 1)
end

function AudioManager.PlaySFX( name )
    Play('sfx', name, false, 0)
end

function AudioManager.SetMainVolume(val)
    
end

function AudioManager.SetBGMVolume(val)
    SetVolume('bgm', val)
end

function AudioManager.SetSFXVolume(val)
    SetVolume('sfx', val)
end

function AudioManager.SetBGMMute( b )
    SetMute('bgm', b)
end

function AudioManager.SetSFXMute( b )
    SetMute('sfx', b)
end


Init()