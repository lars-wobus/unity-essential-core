using Essential.Core.UI.Table.Interfaces;
using UnityEngine;

namespace Essential.Core.UI.Table
{
	public class Table : ITable
	{
		private readonly GameObject _rowPrefab;
		private readonly GameObject _columnPrefab;

		public Table(GameObject rowPrefab, GameObject columnPrefab)
		{
			_rowPrefab = rowPrefab;
			_columnPrefab = columnPrefab;
		}

		public Transform AddRow(Transform parent)
		{
			return Object.Instantiate(_rowPrefab, parent).transform;
		}
		
		public Transform AddColumn(Transform parent)
		{
			return Object.Instantiate(_columnPrefab, parent).transform;
		}
	}
}
