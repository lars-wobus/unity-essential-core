﻿using System;
using System.Collections.Generic;
using Essential.Core.Scripts.UI.Table.Data;
using Essential.Core.UI.Table.Data;
using Essential.Core.UI.Table.Interfaces;
using TMPro;
using UnityEngine;

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

			//Debug.Log(JsonUtility.ToJson(_tableData));
			Render();
		}

		private void BuildTableRecursive(IEnumerable<TableCell> cells, Transform parent)
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
					case TableCellType.Text:
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
						BuildTableRecursive(TableData.FindCells(_tableData.Body, cell.Refs), layoutElement);
						break;
					}
					default:
					{
						throw new ArgumentOutOfRangeException();
					}	
				}
			}
		}

		public void Render()
		{
			var root = TableData.FindCells(_tableData.Body, new[] {_tableData.Body[0].Id});
			BuildTableRecursive(root, _tableBody);
		}
	}
}