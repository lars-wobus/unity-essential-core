﻿using System;
using System.Collections.Generic;
using Essential.Core.UI.Table.Data;
using Essential.Core.UI.Table.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Essential.Core.UI.Table
{
	public class UiTable : MonoBehaviour
	{
		private static int MaxDepth = 10;
		
		[SerializeField] private TableData _tableData;
		[SerializeField] private Transform _tableBody;
		[SerializeField] private TableStyle _style;
		
		private ITable Table { get; set; }
		private TextRegistry TextRegistry { get; set; }

		private void Start()
		{
			Table = new Table(_style);
			TextRegistry = new TextRegistry();

			Debug.Log(JsonUtility.ToJson(_tableData));
			Render();


			//Interlocked.Increment(ref COUNTER); // TODO
		}

		private void BuildTableRecursive(IEnumerable<TableCell> cells, Transform parent, int depth)
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
							TextRegistry.Register(cell.Id, text);
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

		public void CreateCustomRow(string owerId, string playerNo, string controls, string defaultText, string lives, string description)
		{
			_tableData.AddCell("---1", TableCellType.StaticText, new []{playerNo, controls});
			_tableData.AddCell("---2", TableCellType.DynamicText, new []{defaultText});
			_tableData.AddCell("---3", TableCellType.StaticText, new []{lives, description});
			_tableData.AddCell("---4", TableCellType.Row, new []{"---1", "---2", "---3"});
			var first = _tableData.FindTableCell(owerId);
			if (first != null) first.Refs.Add("---4");
		}

		public void Render()
		{
			//_tableData.AddCell("-1", TableCellType.Row, new List<string>{"7"});
			_tableData.AddCell("-1", TableCellType.DynamicText, new []{"7"});
			var first = _tableData.FindTableCell("1");
			if (first != null) first.Refs.Add("-1");

			CreateCustomRow("1", "player1", "gamepad", "nothing", "5", "Has no items");
			
			var root = TableData.FindCells(_tableData.Body, new []{_tableData.Body[0].Id});
			BuildTableRecursive(root, _tableBody, 0);
			ChangeBackgroundColors(_tableBody);
		}

		private int i = 0;
		private void Update()
		{
			TextRegistry.UpdateText("-1", (i++).ToString());
			TextRegistry.UpdateText("---2", (i++).ToString());
		}
	}
}
