using System.Collections.Generic;
using UnityEngine;
using XLua;

public class ReuseScrollView : ReuseScrollViewBase<ReuseScollViewItemData> {
    protected override void Start() {
        base.Start();
    }
    int lastID = 1;
    LuaFunction callback;
    public void Init(GameObject prefab, int count, LuaFunction cb) {
        callback = cb;
        cellObject = prefab;
        var items = new List<ReuseScollViewItemData>();
        for(int i=0; i < count;i++) {
            items.Add(new ReuseScollViewItemData { id = lastID++, cb = callback });
        }
        CellData = items;
    }
    public void Remove(int id) {
        foreach(var data in CellData) {
            if (id == data.id) {
                CellData.Remove(data);
                break;
            }
        }
        ReloadData(false);
    }
    public int Append() {
        var item = new ReuseScollViewItemData { id = lastID++, cb = callback };
        CellData.Add(item);
        ReloadData(false);
        return item.id;
    }
    public void Insert(int idx) {
        CellData.Insert(idx, new ReuseScollViewItemData { id = lastID++, cb = callback });
        ReloadData(false);
    }
}
