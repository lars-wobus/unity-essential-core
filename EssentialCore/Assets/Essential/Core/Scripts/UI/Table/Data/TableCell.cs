using System;
using Essential.Core.Scripts.UI.Table.Data;
using UnityEngine;

namespace Essential.Core.UI.Table.Data
{
	[Serializable]
	public class TableCell : TableCellBase<string>
	{
		[SerializeField] private TableCellType _type;
		[SerializeField] private string[] _refs;
		
		public TableCellType Type
		{
			get { return _type; }
			set { _type = value; }
		}
		
		public string[] Refs
		{
			get { return _refs; }
			set { _refs = value; }
		}
	}
}
