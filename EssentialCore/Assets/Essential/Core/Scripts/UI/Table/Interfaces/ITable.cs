﻿using Essential.Core.UI.Table.Data;
using UnityEngine;

namespace Essential.Core.UI.Table.Interfaces
{
    public interface ITable
    {
        GameObject CreateCell(TableCellType type, Transform parent);
    }
}
