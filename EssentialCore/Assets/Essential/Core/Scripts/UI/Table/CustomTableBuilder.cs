using Essential.Core.UI.Table.Data;
using UnityEngine;

namespace Essential.Core.UI.Table
{
	public class CustomTableBuilder : UiTable
	{
		// Test
		private CustomTableBuilder()
		{
			CreateCustomRow("player1", "gamepad", "nothing", "5", "Has no items");
			Render();
		}
		
		public void CreateCustomRow(string playerNo, string controls, string defaultText, string lives, string description)
		{
			Add("---1", TableCellType.StaticText, new []{playerNo, controls});
			Add("---2", TableCellType.DynamicText, new []{defaultText});
			Add("---3", TableCellType.StaticText, new []{lives, description});
			Add("---4", TableCellType.Row, new []{"---1", "---2", "---3"});
			
			GetRoot()?.Refs.Add("---4");
		}
	}
}
