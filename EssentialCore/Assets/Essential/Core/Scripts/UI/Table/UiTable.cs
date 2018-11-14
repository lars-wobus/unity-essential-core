using System.Collections.Generic;
using Essential.Core.UI.Table.Data;
using Essential.Core.UI.Table.Interfaces;
using UnityEngine;

namespace Essential.Core.UI.Table
{
	public class UiTable : MonoBehaviour
	{
		private const int MaxDepth = 10;
		
		[SerializeField] private TableData _tableData;
		[SerializeField] private Transform _tableBody;
		[SerializeField] private TableStyle _style;
		
		private ITableDecorator Decorator { get; set; }
		private TableLayout TableLayout { get; set; }

		private void Awake()
		{
			TableLayout = new TableLayout(new Table(_style));
			Decorator = GetComponent<ITableDecorator>();

			Debug.Log(JsonUtility.ToJson(_tableData));
			Render();
		}
		
		public void Render()
		{
			CreateTable(new[]{"1"}, _tableBody, 0);
			Decorator?.UpdateColors(_tableBody.GetChild(0), _style);
		}

		public void Add(string id, TableCellType type, ICollection<string> refs)
		{
			_tableData.AddCell(id, type, refs);
			// TODO Render
		}

		public TableCell GetRoot()
		{
			return _tableData.GetRootCell();
		}

		private void CreateTable(ICollection<string> refs, Transform parent, int depth)
		{
			if (depth > MaxDepth)
			{
				Debug.LogWarning("Max Depth Reached");
				return;
			}
			
			var cells = _tableData.FindCells(refs);
			TableLayout.CreateTable(cells, parent, depth + 1, CreateTable);
		}
	}
}
