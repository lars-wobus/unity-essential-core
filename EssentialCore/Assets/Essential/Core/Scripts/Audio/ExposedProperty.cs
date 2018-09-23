using UnityEngine;
using System;

namespace Essential.Core.Audio
{
	[Serializable]
	public class ExposedProperty
	{
		[SerializeField] private string _name;

		public string Name => _name;

		public ExposedProperty(string name)
		{
			_name = name;
		}
	}
}
