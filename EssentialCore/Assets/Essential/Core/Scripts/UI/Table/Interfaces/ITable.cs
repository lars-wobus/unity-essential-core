using UnityEngine;

namespace Essential.Core.UI.Table.Interfaces
{
    public interface ITable
    {
        Transform AddRow(Transform parent);
        Transform AddColumn(Transform parent);
    }
}
