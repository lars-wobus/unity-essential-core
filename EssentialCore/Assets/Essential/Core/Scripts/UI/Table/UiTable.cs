using System;
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
		[SerializeField] private Transform _tableBody;
		[SerializeField] private TableStyle _style;
		
		private ITable Table { get; set; }

		private void Start()
		{
			Table = new Table(_style);

			Debug.Log(JsonUtility.ToJson(_tableData));
			Render();
		}

		private void BuildTableRecursive(IEnumerable<TableCell> cells, Transform parent, int depth)
		{
			foreach (var cell in cells)
			{
				switch (cell.Type)
				{
					case TableCellType.Empty:
					{
						foreach (var content in cell.Refs)
						{
							Table.CreateCell(cell.Type, parent);
						}
						break;
					}
					case TableCellType.StaticText:
					{
						foreach (var content in cell.Refs)
						{
							var text = Table.CreateCell(cell.Type, parent).GetComponent<TMP_Text>();
							text.text = content;
						}
						break;
					}
					case TableCellType.DynamicText:
					{
						foreach (var content in cell.Refs)
						{
							var text = Table.CreateCell(cell.Type, parent).GetComponent<TMP_Text>();
							text.text = content;
						}
						break;
					}
					case TableCellType.Row:
					case TableCellType.Column:
					{
						var layoutElement = Table.CreateCell(cell.Type, parent).transform;
						BuildTableRecursive(TableData.FindCells(_tableData.Body, cell.Refs), layoutElement, depth + 1);
						break;
					}
					default:
					{
						throw new ArgumentOutOfRangeException();
					}	
				}
			}
		}

		private void ChangeBackgroundColors(Transform parent)
		{
			var primeChild = parent.GetChild(0);
			if (primeChild == null)
			{
				return;
			}

			var index = 0;
			foreach (Transform child in primeChild)
			{
				Debug.Log(child);
				var image = child.GetComponent<Image>();
				if (image == null)
				{
					continue;
				}
				
				image.color = _style.Colors[index++ % _style.Colors.Length];
			}
		}

		public void Render()
		{
			_tableData.AddCell("-1", TableCellType.Row, new List<string>{"7"});
			var first = _tableData.FindTableCell("1");
			if (first != null) first.Refs.Add("-1");
			var root = TableData.FindCells(_tableData.Body, new List<string> {_tableData.Body[0].Id});
			BuildTableRecursive(root, _tableBody, 0);
			ChangeBackgroundColors(_tableBody);
		}
	}
}
