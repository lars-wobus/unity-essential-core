using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

namespace Essential.Core.UI.Table.Data
{
    [Serializable]
    public class TableData
    {
        [SerializeField] private List<TableCell> _body;

        public List<TableCell> Body => _body;

        public static IEnumerable<TableCell> FindCells(IEnumerable<TableCell> cells, ICollection<string> ids)
        {
            return ids.Count == 0 ? null : cells.Where(element => ids.Contains(element.Id));
        }

        public void AddCell(string id, TableCellType type, ICollection<string> refs)
        {
            _body.Add(new TableCell()
            {
                Id = id,
                Type = type,
                Refs = refs
            });
        }

        public TableCell FindTableCell(string id)
        {
            return string.IsNullOrEmpty(id) ? null : _body.FirstOrDefault(element => element.Id == id);
        }
    }
}
