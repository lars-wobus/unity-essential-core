using System;
using System.Collections.Generic;
using Essential.Core.UI.Table.Data;
using Essential.Core.UI.Table.Interfaces;
using TMPro;
using UnityEngine;

namespace Essential.Core.UI.Table
{
	public class TableDrawer {

		private const int MaxDepth = 10;
	
		private ITable Table { get; }
		private TableData Data { get; }
		private TextRegistry TextRegistry { get; }

		public TableDrawer(ITable table, TableData data)
		{
			Table = table;
			Data = data;
			TextRegistry = new TextRegistry();
		}
	
		public void BuildTableRecursive(IEnumerable<TableCell> cells, Transform parent, int depth)
		{
			if (depth > MaxDepth)
			{
				Debug.LogWarning("Max Depth Reached");
				return;
			}
			
			foreach (var cell in cells)
			{
				switch (cell.Type)
				{
					case TableCellType.Empty:
					{
						for(var index = 0; index < cell.Refs.Count; ++index)
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
							TextRegistry.Register(cell.Id, text);
						}
						break;
					}
					case TableCellType.Row:
					case TableCellType.Column:
					{
						var layoutElement = Table.CreateCell(cell.Type, parent).transform;
						BuildTableRecursive(Data.FindCells(cell.Refs), layoutElement, depth + 1);
						break;
					}
					default:
					{
						throw new ArgumentOutOfRangeException();
					}	
				}
			}
		}
	}
}
