using System;
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
		[SerializeField] private TableData _tableData;
		[SerializeField] private Transform _tableBody;
		[SerializeField] private TableStyle _style;
		
		private ITableDecorator Decorator { get; set; }
		private TableDrawer TableDrawer { get; set; }

		private void Awake()
		{
			TableDrawer = new TableDrawer(new Table(_style), _tableData);
			Decorator = GetComponent<ITableDecorator>();

			Debug.Log(JsonUtility.ToJson(_tableData));
			Render();
		}
		
		public void Render()
		{
			var root = _tableData.GetRootCell();
			TableDrawer?.BuildTableRecursive(new[]{root}, _tableBody, 0);	
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
	}
}
