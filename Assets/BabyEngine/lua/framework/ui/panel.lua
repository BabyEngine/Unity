local panelBaseName
local defaultParent
local showList = {}
local showListCount = 0

local SwitchLangEvent

function PanelSetBasePath( n )
    panelBaseName = n
end

function PanelSetDefaultRoot( p )
    defaultParent = p
end

-- 获取当前所有正在显示的面板
function PanelListShow()
    return showList, showListCount
end
function PanelIsOnTop( p )
    if not p.IsVisiable() then return false end
    local top = PanelOnTop()
    return p == top
end
function PanelOnTop( )
    -- 先根据 层级去排序
    local sortedByLevel = {}
    local maxLevel = -1
    for k,v in pairs(showList) do
        sortedByLevel[v.level] = sortedByLevel[v.level] or {}
        table.insert(sortedByLevel[v.level], v)
        if v.level > maxLevel then maxLevel = v.level end
    end
    -- 得到最大层级的正在展示的面板
    local panels = sortedByLevel[maxLevel] or {}
    local maxSiblingIndex = -1
    local topPanel = nil
    for i,v in ipairs(panels) do
        local idx = v.transform:GetSiblingIndex()
        if idx > maxSiblingIndex then
            maxSiblingIndex = idx
            topPanel = v
        end
    end
    return topPanel
end
function PanelBase(path, level)
    local originPath = path
    local self = ParseUI()
    self.gameObject = nil
    self.transform  = nil
    local isShown = false
    self.path = path
    self.level = level
    local prefabPath

    local function onUpdate()
        if not self.onUpdate then return end
        self.onUpdate()
    end

    function self.Show(cb, parent, afterHide)
        if isShown then return end
        if not prefabPath then
            prefabPath = originPath
            if panelBaseName then
                prefabPath = panelBaseName .. path
            end
        end
        if self.gameObject == nil then
            ResourceManager:LoadObject(prefabPath, function ( obj )
                if obj == nil then
                    error('Panel Not Exist:' .. path)
                    return
                end
                self.gameObject = Instantiate(obj)
                self.transform = self.gameObject.transform
                self.gameObject.name = obj.name
                parent = parent or defaultParent
                if parent ~= nil and parent == defaultParent then -- 是默认的root
                    if type(level) == 'number' then
                        local node = defaultParent.transform:GetChild(level - 1)
                        if node then
                            parent = node
                        end
                    end
                end
                if parent and parent.transform then
                    self.transform:SetParent(parent.transform, false)
                end
                if type(self.ctor) == 'function' then
                    self.ctor()
                end
                self.Show(cb, parent, afterHide)
            end)
        else
            isShown = true
            showList[self] = self
            Looper.AddUpdate(onUpdate)
            showListCount = showListCount + 1

            if type(self.onShow) == 'function' then
                self.onShow()
            end
            self.gameObject:SetActive(true)
            self.transform:SetAsLastSibling()
            if type(afterHide) == 'function' then
                self.afterHide = afterHide
            end
            if cb then
                cb()
            end
            if type(self.afterShow) == 'function' then
                self.afterShow()
            end
        end
    end

    function self.Hide(cb)
        if not isShown then return end
        if self.gameObject then
            self.gameObject:SetActive(false)
        end
        isShown = false
        showList[self] = nil
        Looper.RemoveUpdate(onUpdate)
        showListCount = showListCount - 1
        if type(self.onHide) == 'function' then
            self.onHide()
        end
        if type(afterHide) == 'function' then
            self.afterHide()
        end
        if cb then
            cb()
        end
    end

    function self.Release(cb)
        self.Hide()
        if type(self.dtor) == 'function' then
            self.dtor()
        end
        if self.gameObject then
            Destroy(self.gameObject)
        end
        self.gameObject = nil
        self.transform = nil
    end

    function self.BindUI( t )
        if t == nil then
            local modName = originPath .. '_AutoBind'
            t = require(modName)
        end
        self.InitParser(self.transform, t)
        return self
    end

    function self.IsVisiable()
        return isShown
    end
    return self
end

function PanelInclude( panels )
    for k,v in pairs(panels) do
        local tmp = string.split(v)
        local name = tmp[#tmp]
        _G[name] = require(v)
    end
end
