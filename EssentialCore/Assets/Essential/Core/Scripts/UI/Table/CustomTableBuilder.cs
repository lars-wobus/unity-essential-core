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
			//Render();
		}
		
		public void CreateCustomRow(string playerNo, string controls, string defaultText, string lives, string description)
		{
			AddItemData("---1", TableCellType.StaticText, new []{playerNo, controls});
			AddItemData("---2", TableCellType.DynamicText, new []{defaultText});
			AddItemData("---3", TableCellType.StaticText, new []{lives, description});
			AddItemData("---4", TableCellType.Row, new []{"---1", "---2", "---3"});
			
			GetRootData()?.Refs.Add("---4");

			var parent = GetRootItem();
			CreateTable(new[]{"--4"}, parent, 1);
		}
	}
}
