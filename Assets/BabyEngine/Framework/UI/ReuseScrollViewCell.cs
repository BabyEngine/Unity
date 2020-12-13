using XLua;

public class ReuseScrollViewCell : ReuseScollViewCellBase<ReuseScollViewItemData> {
    public override void UpdateContent(ReuseScollViewItemData item) {
        if (item.cb != null) {
            item.cb.Call(gameObject, item.id);
        }
    }
}

[System.Serializable]
public struct ReuseScollViewItemData {
    public int id;
    public LuaFunction cb;
}