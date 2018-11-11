﻿using System;
using Essential.Core.Scripts.UI.Table.Data;
using Essential.Core.UI.Table.Interfaces;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Essential.Core.UI.Table
{
	public class Table : ITable
	{
		private ITableStyle Style { get; }
		
		public Table(ITableStyle style)
		{
			Style = style;
		}

		public GameObject CreateCell(TableCellType type, Transform parent)
		{
			switch (type)
			{
				case TableCellType.Empty:
				{
					return Object.Instantiate(Style.Empty, parent);
				}
				case TableCellType.Text:
				{
					return Object.Instantiate(Style.Text, parent);
				}
				case TableCellType.Row:
				{
					return Object.Instantiate(Style.Row, parent);
				}
				case TableCellType.Column:
				{
					return Object.Instantiate(Style.Column, parent);
				}
				default:
				{
					throw new ArgumentOutOfRangeException();
				}	
			}
		}
	}
}