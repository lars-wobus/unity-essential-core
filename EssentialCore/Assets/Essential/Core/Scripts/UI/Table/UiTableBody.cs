using Essential.Core.Scripts.UI.Table.Data;
using Essential.Core.UI.Table.Data;
using Essential.Core.UI.Table.Interfaces;
using UnityEngine;

namespace Essential.Core.UI.Table
{
	public class UiTableBody : MonoBehaviour, ITableBody
	{
		[SerializeField] private RectTransform _tableBody;
		[SerializeField] private GameObject _rowPrefab;
		
		public Transform Root => _tableBody;

		public Transform AddRow(Transform parent)
		{
			return Instantiate(_rowPrefab, parent).transform;
		}

		public void RemoveRow()
		{
			throw new System.NotImplementedException();
		}
	}
}
