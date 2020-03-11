-- 导出常用Unity函数
Destroy = CS.UnityEngine.Object.Destroy
Instantiate = CS.UnityEngine.Object.Instantiate
GameObject = CS.UnityEngine.GameObject

function Int32ToBytes(int)
    if type(int) ~= 'number' then return end
    int = math.floor(int) or 0
    local t = {
        (int & 0xff000000) >> 24,
        (int & 0x00ff0000) >> 16,
        (int & 0x0000ff00) >> 8,
        (int & 0x000000ff),
    }
    return string.char(table.unpack(t))
end