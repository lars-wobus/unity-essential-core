using UnityEngine;

namespace Essential.Core.UI.Table.Interfaces
{
    public interface ITableBody
    {
        Transform Root { get; }
        
        Transform AddRow(Transform parent);
        void RemoveRow();
    }
}
