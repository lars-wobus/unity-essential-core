using System.Collections.Generic;
using Essential.Core.Scripts.UI.Table.Data;
using Essential.Core.UI.Table.Data;
using Essential.Core.UI.Table.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Essential.Core.UI.Table
{
	public class UiTable : MonoBehaviour
	{
		[SerializeField] private TableData _tableData;
		[SerializeField] private GameObject _textPrefab;
		
		private ITableHead TableHead { get; set; }
		private ITableBody TableBody { get; set; }

		private void Start()
		{
			TableHead = GetComponent<ITableHead>();
			TableBody = GetComponent<ITableBody>();

			Debug.Log(JsonUtility.ToJson(_tableData));
			//_tableData.RootCell;
			BuildTableRecursive(_tableData.Cells, TableBody.Root);
		}

		public void BuildTableRecursive(IEnumerable<TableCell> cells, Transform parent)
		{
			foreach (var cell in cells)
			{
				Debug.Log(cell.Type);
				switch (cell.Type)
				{
					case TableCellType.Empty:
					{
						foreach (var content in cell.Refs)
						{
							Instantiate(_textPrefab, parent);
						}
						break;
					}
					case TableCellType.Text:
					{
						foreach (var content in cell.Refs)
						{
							var text = Instantiate(_textPrefab, parent).GetComponent<TMP_Text>();
							text.text = content;
						}
						break;
					}
					case TableCellType.Row:
					{
						Debug.Log("Row " + cell.Id);
						var row = AddRow(parent);
						Debug.Log("Row " + row);
						BuildTableRecursive(_tableData.FindCells(cell.Refs), row);
						break;
					}
					case TableCellType.Column:
					{
						Transform column = null;
						BuildTableRecursive(_tableData.FindCells(cell.Refs), column);
						break;
					}
					default:
					{
						break;
					}
				}
			}
		}

		public void AddColumn()
		{
			TableHead.AddColumn();
		}

		public void RemoveColumn()
		{
			TableHead.RemoveColumn();
		}

		public Transform AddRow(Transform parent)
		{
			return TableBody.AddRow(parent);
		}

		public void RemoveRow()
		{
			TableBody.RemoveRow();
		}
	}
}
