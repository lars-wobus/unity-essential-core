using System;
using System.Collections.Generic;
using System.Linq;
using Essential.Core.UI.Table.Data;
using UnityEngine;

[Serializable]
public class TableData
{
    [SerializeField] private TableCell[] _cells;

    public TableCell[] Cells => _cells;

    public TableCell FindCell(string id)
    {
        return _cells.FirstOrDefault(element => element.Id == id);
    }
    
    public IEnumerable<TableCell> FindCells(string[] ids)
    {
        return _cells.Where(element => ids.Contains(element.Id));
    }
}
