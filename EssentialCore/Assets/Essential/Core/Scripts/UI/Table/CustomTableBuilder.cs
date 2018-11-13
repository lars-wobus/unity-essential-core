using Essential.Core.UI.Table.Data;
using UnityEngine;

namespace Essential.Core.UI.Table
{
	public class CustomTableBuilder : MonoBehaviour
	{
		private UiTable UiTable { get; set; }
	
		public void CreateCustomRow(string playerNo, string controls, string defaultText, string lives, string description)
		{
			UiTable.Add("---1", TableCellType.StaticText, new []{playerNo, controls});
			UiTable.Add("---2", TableCellType.DynamicText, new []{defaultText});
			UiTable.Add("---3", TableCellType.StaticText, new []{lives, description});
			UiTable.Add("---4", TableCellType.Row, new []{"---1", "---2", "---3"});
			
			UiTable.GetRoot()?.Refs.Add("---4");
		}

		private void Start()
		{
			UiTable = GetComponent<UiTable>();
			
			// Test
			CreateCustomRow("player1", "gamepad", "nothing", "5", "Has no items");
			UiTable.Render();
		}
	}
}
