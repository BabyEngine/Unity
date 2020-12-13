-- @luadoc 创建对象池
-- @params prefab       GameObject 预设
-- @params initSize     int        初始创建数量
-- @params freeCapacity int        最多保存几个未使用的数量
function NewObjectPool( prefab, initSize, freeCapacity )
    local p = {}
    local freeList  = {} -- 可用池子 数组
    local usingList = {} -- 正在使用 字典
    initSize = initSize or 0
    freeCapacity = freeCapacity or 3
    function p.Init()
        p.Release()
        p.IsRelease = false
        if initSize > 0 then
            for i=1,initSize do
                local obj = Instantiate(prefab)
                obj.name = prefab.name
                table.insert(freeList, obj)
            end
        end
    end
    function p.Get()
        if #freeList == 0 then
            local obj = Instantiate(prefab)
            obj.name = prefab.name
            usingList[obj] = obj
            obj:SetActive(true)
            return obj
        else
            local obj = freeList[1]
            table.remove(freeList, 1)
            usingList[obj] = obj
            obj:SetActive(true)
            return obj
        end
    end
    function p.Put( obj, destroy )
        if usingList[obj] then
            obj:SetActive(false)
            usingList[obj] = nil
            if not destroy then
                if #freeList < freeCapacity then
                    table.insert(freeList, obj)
                else
                    Destroy(obj.gameObject)
                end
            else
                Destroy(obj.gameObject)
            end
        end
    end
    function p.Release()
        for k,v in pairs(freeList) do
            if v then
                Destroy(v)
            end
        end
        freeList = {}

        for k,v in pairs(usingList) do
            if v then
                Destroy(v)
            end
        end
        usingList = {}
    end
    return p
end

function NewLuaPool( newFunc, size )
    local self = {}
    size = size or 16
    local freeObjects = {}
    function self.Init()
        for _ = 1, size do
            table.insert(freeObjects, newFunc())
        end
    end
    function self.Put( obj )
        table.insert(freeObjects, obj)
    end

    function self.Get()
        return #freeObjects == 0 and newFunc() or
            table.remove(freeObjects)
    end

    function self.Release()
        freeObjects = {}
    end

    return self
end