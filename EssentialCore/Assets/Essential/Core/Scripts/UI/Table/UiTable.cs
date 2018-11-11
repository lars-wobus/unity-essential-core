using System.Collections.Generic;
using System.Linq;
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
		[SerializeField] private Transform TableBodyGo;
		[SerializeField] private GameObject _rowPrefab;
		[SerializeField] private GameObject _columnPrefab;
		
		private ITable Table { get; set; }

		private void Start()
		{
			Table = new Table(_rowPrefab, _columnPrefab);

			Debug.Log(JsonUtility.ToJson(_tableData));
			BuildTableRecursive(TableData.FindCells(_tableData.Body, new[]{_tableData.Body[0].Id}), TableBodyGo);
		}

		public void BuildTableRecursive(IEnumerable<TableCell> cells, Transform parent)
		{
			foreach (var cell in cells)
			{
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
						var row = AddRow(parent);
						BuildTableRecursive(TableData.FindCells(_tableData.Body, cell.Refs), row);
						break;
					}
					case TableCellType.Column:
					{
						var column = AddColumn(parent);
						BuildTableRecursive(TableData.FindCells(_tableData.Body, cell.Refs), column);
						break;
					}
					default:
					{
						break;
					}
				}
			}
		}

		public Transform AddColumn(Transform parent)
		{
			return Table.AddColumn(parent);
		}

		public Transform AddRow(Transform parent)
		{
			return Table.AddRow(parent);
		}
	}
}
