-- 导出常用Unity函数
Destroy     = CS.UnityEngine.Object.Destroy
Instantiate = CS.UnityEngine.Object.Instantiate
GameObject  = CS.UnityEngine.GameObject
Time        = CS.UnityEngine.Time
NewObject   = Instantiate
Vector4     = CS.UnityEngine.Vector2
Vector3     = CS.UnityEngine.Vector3
Vector2     = CS.UnityEngine.Vector2
Quaternion  = CS.UnityEngine.Quaternion
Color       = CS.UnityEngine.Color
Camera      = CS.UnityEngine.Camera
Screen      = CS.UnityEngine.Screen
Mathf       = CS.UnityEngine.Mathf
Canvas      = CS.UnityEngine.Canvas
NewObject   = CS.UnityEngine.Object.Instantiate
function Destroy( ... )
    local gameObject = select(1, ...)
    if gameObject == nil or CS.UnityEngine.GameObject.ReferenceEquals(gameObject, nil) then return end
    CS.UnityEngine.Object.Destroy(...)
end

function ObjectRename( o, name )
    if not o then return end
    if name then
        o.name = name
    else
        o.name = string.replace(o.name, '(Clone)', '')
    end
end

function ObjectCheck( obj )
    if obj and obj.gameObject then
        return obj.gameObject:IsDestroyed() == false
    end
    return false
end

function math.clamp( val, min, max )
    if val < min then return min end
    if val > max then return max end
    return val
end
function math.clamp01( val )
    return math.clamp(val, 0, 1)
end
function math.roundN( val, n )
    local p = 1 / 10^n
    local num = val - (val%p)
    local t1, t2 = math.modf( num )
    if t2 == 0 then
        return t1
    else
        return num
    end
end
function math.inRange( val, min, max )
    if val >= min and val <= max then return true end
    return false
end
