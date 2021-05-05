function NewReuseScrollView( scrollView, cell, n, cb )
    local self = {}
    local gameObject = scrollView.gameObject
    local comp = gameObject:GetComponent(typeof(CS.ReuseScrollView))
    if comp then
        comp:Init(cell, n, cb)
    end
    function self.Append( n )
        if not comp then return end
        comp:Append(n)
    end
    function self.Insert( idx )
        if not comp then return end
        comp:Insert(idx)
    end
    function self.Remove( idx )
        if not comp then return end
        comp:Remove(idx)
    end
    return self
end
