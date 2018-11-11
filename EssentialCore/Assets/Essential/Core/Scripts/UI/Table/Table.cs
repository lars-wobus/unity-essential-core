using System;
using Essential.Core.Scripts.UI.Table.Data;
using Essential.Core.UI.Table.Interfaces;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Essential.Core.UI.Table
{
	public class Table : ITable
	{
		private readonly GameObject _textPrefab;
		private readonly GameObject _rowPrefab;
		private readonly GameObject _columnPrefab;

		public Table(GameObject textPrefab, GameObject rowPrefab, GameObject columnPrefab)
		{
			_textPrefab = textPrefab;
			_rowPrefab = rowPrefab;
			_columnPrefab = columnPrefab;
		}

		public GameObject CreateCell(TableCellType type, Transform parent)
		{
			switch (type)
			{
				case TableCellType.Empty:
				{
					return Object.Instantiate(_textPrefab, parent);
				}
				case TableCellType.Text:
				{
					return Object.Instantiate(_textPrefab, parent);
				}
				case TableCellType.Row:
				{
					return Object.Instantiate(_rowPrefab, parent);
				}
				case TableCellType.Column:
				{
					return Object.Instantiate(_columnPrefab, parent);
				}
				default:
				{
					throw new ArgumentOutOfRangeException();
				}	
			}
		}
	}
}
