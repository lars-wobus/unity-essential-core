using System;
using System.Collections.Generic;
using System.Linq;
using Essential.Core.Scripts.UI.Table.Data;
using UnityEngine;

namespace Essential.Core.UI.Table.Data
{
    [Serializable]
    public class TableData
    {
        [SerializeField] private List<TableCell> _body;

        public List<TableCell> Body => _body;

        public static IEnumerable<TableCell> FindCells(IEnumerable<TableCell> cells, List<string> ids)
        {
            return cells.Where(element => ids.Contains(element.Id));
        }

        public void AddCell(string id, TableCellType type, List<string> refs)
        {
            var cell = new TableCell(){ Id = id, Type = type, Refs = refs};
            _body.Add(cell);
        }

        public TableCell FindTableCell(string id)
        {
            return _body.FirstOrDefault(element => element.Id == id);;
        }
    }
}
