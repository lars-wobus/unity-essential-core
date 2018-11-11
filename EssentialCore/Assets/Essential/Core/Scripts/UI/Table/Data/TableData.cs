﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Essential.Core.UI.Table.Data
{
    [Serializable]
    public class TableData
    {
        [SerializeField] private List<TableCell> _body;

        public List<TableCell> Body => _body;

        public static IEnumerable<TableCell> FindCells(IEnumerable<TableCell> cells, string[] ids)
        {
            return cells.Where(element => ids.Contains(element.Id));
        }
    }
}
