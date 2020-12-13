using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using XLua;
[LuaCallCSharp]
[RequireComponent(typeof(RectTransform), typeof(ScrollRect))]
public abstract class ReuseScrollViewBase<T> : UIBehaviour {
    public ReuseScrollViewDirection scrollDirection;
    protected GameObject cellObject;
    public float defaultCellSize = 200.0f;
    public float spacing = 20.0f;
    public RectOffset contentPadding;
    public float activePadding;

    private RectTransform rectTransform;
    private ScrollRect scrollRect;
    private Vector2 scrollPosition;
    private LinkedList<ReuseScollViewCellBase<T>> cells = new LinkedList<ReuseScollViewCellBase<T>>();

    private List<T> cellData = new List<T>();
    protected List<T> CellData {
        get {
            return cellData;
        }
        set {
            cellData = value;
            ReloadData(true);
        }
    }

    protected override void Awake() {
        base.Awake();
        rectTransform = GetComponent<RectTransform>();
        scrollRect = GetComponent<ScrollRect>();

        RectTransform contentRectTransform = scrollRect.content.GetComponent<RectTransform>();
        if (scrollDirection == ReuseScrollViewDirection.Vertical) {
            contentRectTransform.anchorMin = Vector2.up;
            contentRectTransform.anchorMax = Vector2.one;
        } else if (scrollDirection == ReuseScrollViewDirection.Horizontal) {
            contentRectTransform.anchorMin = Vector2.zero;
            contentRectTransform.anchorMax = Vector2.up;
        }
        contentRectTransform.anchoredPosition = Vector2.zero;
        contentRectTransform.sizeDelta = Vector2.zero;

        scrollRect.onValueChanged.AddListener(OnScrolled);
    }
#if UNITY_EDITOR
    protected override void OnValidate() {
        base.OnValidate();
        if (cellObject && !cellObject.GetComponent<ReuseScollViewCellBase<T>>()) {
            //cellObject = null;
            
        }
    }
#endif
    private void OnScrolled(Vector2 pos) {
        ReuseCells(pos - scrollPosition);
        FillCells();
        scrollPosition = pos;
    }

    protected void ReloadData(bool isReset = false) {
        Vector2 sizeDelta = scrollRect.content.sizeDelta;
        float contentSize = 0;
        for (int i = 0; i < cellData.Count; i++) {
            contentSize += GetCellSize(i) + (i > 0 ? spacing : 0);
        }
        if (scrollDirection == ReuseScrollViewDirection.Vertical) {
            contentSize += contentPadding.vertical;
            sizeDelta.y = contentSize > rectTransform.rect.height ? contentSize : rectTransform.rect.height;
        } else if (scrollDirection == ReuseScrollViewDirection.Horizontal) {
            contentSize += contentPadding.horizontal;
            sizeDelta.x = contentSize > rectTransform.rect.width ? contentSize : rectTransform.rect.width;
        }
        scrollRect.content.sizeDelta = sizeDelta;

        if (isReset) {
            foreach (var cell in cells) {
                Destroy(cell.gameObject);
            }
            cells.Clear();

            scrollRect.normalizedPosition = scrollRect.content.GetComponent<RectTransform>().anchorMin;
            scrollRect.onValueChanged.Invoke(scrollRect.normalizedPosition);
        } else {
            UpdateCells();
            FillCells();
        }
    }

    private void CreateCell(int index) {
        var cell = Instantiate(cellObject).GetComponent<ReuseScollViewCellBase<T>>();
        cell.SetAnchors(scrollRect.content.anchorMin, scrollRect.content.anchorMax);
        cell.transform.SetParent(scrollRect.content.transform, false);
        UpdateCell(cell, index);

        if (scrollDirection == ReuseScrollViewDirection.Vertical) {
            cell.Top = (cells.Count > 0 ? cells.Last.Value.Bottom - spacing : -contentPadding.top);
            cell.SetOffsetHorizontal(contentPadding.left, contentPadding.right);
        } else if (scrollDirection == ReuseScrollViewDirection.Horizontal) {
            cell.Left = (cells.Count > 0 ? cells.Last.Value.Right + spacing : contentPadding.left);
            cell.SetOffsetVertical(contentPadding.top, contentPadding.bottom);
        }

        cells.AddLast(cell);
    }

    private void UpdateCell(ReuseScollViewCellBase<T> cell, int index) {
        cell.dataIndex = index;
        if (cell.dataIndex >= 0 && cell.dataIndex < cellData.Count) {
            if (scrollDirection == ReuseScrollViewDirection.Vertical) {
                cell.Height = GetCellSize(cell.dataIndex);
            } else if (scrollDirection == ReuseScrollViewDirection.Horizontal) {
                cell.Width = GetCellSize(cell.dataIndex);
            }
            cell.UpdateContent(cellData[cell.dataIndex]);
            cell.gameObject.SetActive(true);
        } else {
            cell.gameObject.SetActive(false);
        }
    }

    private void UpdateCells() {
        if (cells.Count == 0) return;

        LinkedListNode<ReuseScollViewCellBase<T>> node = cells.First;
        UpdateCell(node.Value, node.Value.dataIndex);
        node = node.Next;
        while (node != null) {
            UpdateCell(node.Value, node.Previous.Value.dataIndex + 1);

            if (scrollDirection == ReuseScrollViewDirection.Vertical) {
                node.Value.Top = node.Previous.Value.Bottom - spacing;
                node.Value.SetOffsetHorizontal(contentPadding.left, contentPadding.right);
            } else if (scrollDirection == ReuseScrollViewDirection.Horizontal) {
                node.Value.Left = node.Previous.Value.Right + spacing;
                node.Value.SetOffsetVertical(contentPadding.top, contentPadding.bottom);
            }

            node = node.Next;
        }
    }

    private void FillCells() {
        if (cells.Count == 0) CreateCell(0);

        while (CellsTailEdge + spacing <= ActiveTailEdge) {
            CreateCell(cells.Last.Value.dataIndex + 1);
        }
    }

    private void ReuseCells(Vector2 scrollVector) {
        if (cells.Count == 0) return;
        
        if (scrollDirection == ReuseScrollViewDirection.Vertical) {
            if (scrollVector.y > 0) {
                while (CellsTailEdge - GetCellSize(cells.Last.Value.dataIndex) >= ActiveTailEdge) {
                    MoveCellLastToFirst();
                }
            } else if (scrollVector.y < 0) {
                while (CellsHeadEdge + GetCellSize(cells.First.Value.dataIndex) <= ActiveHeadEdge) {
                    MoveCellFirstToLast();
                }
            }
        } else if (scrollDirection == ReuseScrollViewDirection.Horizontal) {
            if (scrollVector.x > 0) {
                while (CellsHeadEdge + GetCellSize(cells.First.Value.dataIndex) <= ActiveHeadEdge) {
                    MoveCellFirstToLast();
                }
            } else if (scrollVector.x < 0) {
                while (CellsTailEdge - GetCellSize(cells.Last.Value.dataIndex) >= ActiveTailEdge) {
                    MoveCellLastToFirst();
                }
            }
        }
    }

    private void MoveCellFirstToLast() {
        if (cells.Count == 0) return;

        var firstCell = cells.First.Value;
        var lastCell = cells.Last.Value;
        UpdateCell(firstCell, lastCell.dataIndex + 1);

        if (scrollDirection == ReuseScrollViewDirection.Vertical) {
            firstCell.Top = lastCell.Bottom - spacing;
            firstCell.SetOffsetHorizontal(contentPadding.left, contentPadding.right);
        } else if (scrollDirection == ReuseScrollViewDirection.Horizontal) {
            firstCell.Left = lastCell.Right + spacing;
            firstCell.SetOffsetVertical(contentPadding.top, contentPadding.bottom);
        }

        cells.RemoveFirst();
        cells.AddLast(firstCell);
    }

    private void MoveCellLastToFirst() {
        if (cells.Count == 0) return;

        var lastCell = cells.Last.Value;
        var firstCell = cells.First.Value;
        UpdateCell(lastCell, firstCell.dataIndex - 1);

        if (scrollDirection == ReuseScrollViewDirection.Vertical) {
            lastCell.Bottom = firstCell.Top + spacing;
            lastCell.SetOffsetHorizontal(contentPadding.left, contentPadding.right);
        } else if (scrollDirection == ReuseScrollViewDirection.Horizontal) {
            lastCell.Right = firstCell.Left - spacing;
            lastCell.SetOffsetVertical(contentPadding.top, contentPadding.bottom);
        }

        cells.RemoveLast();
        cells.AddFirst(lastCell);
    }

    protected virtual float GetCellSize(int index) {
        return defaultCellSize;
    }

    private float ActiveHeadEdge {
        get {
            float edge = -activePadding;
            if (scrollDirection == ReuseScrollViewDirection.Vertical) {
                edge += scrollRect.content.anchoredPosition.y;
            } else if (scrollDirection == ReuseScrollViewDirection.Horizontal) {
                edge += -scrollRect.content.anchoredPosition.x;
            }
            return edge;
        }
    }

    private float ActiveTailEdge {
        get {
            float edge = activePadding;
            if (scrollDirection == ReuseScrollViewDirection.Vertical) {
                edge += scrollRect.content.anchoredPosition.y + rectTransform.rect.height;
            } else if (scrollDirection == ReuseScrollViewDirection.Horizontal) {
                edge += -scrollRect.content.anchoredPosition.x + rectTransform.rect.width;
            }
            return edge;
        }
    }

    private float CellsHeadEdge {
        get {
            if (scrollDirection == ReuseScrollViewDirection.Vertical) {
                return cells.Count > 0 ? -cells.First.Value.Top : contentPadding.top;
            } else if (scrollDirection == ReuseScrollViewDirection.Horizontal) {
                return cells.Count > 0 ? cells.First.Value.Left : contentPadding.left;
            }
            return 0;
        }
    }

    private float CellsTailEdge {
        get {
            if (scrollDirection == ReuseScrollViewDirection.Vertical) {
                return cells.Count > 0 ? -cells.Last.Value.Bottom : contentPadding.bottom;
            } else if (scrollDirection == ReuseScrollViewDirection.Horizontal) {
                return cells.Count > 0 ? cells.Last.Value.Right : contentPadding.right;
            }
            return 0;
        }
    }
}
public enum ReuseScrollViewDirection {
    Vertical,
    Horizontal,
}