using UnityEngine;
using System;

namespace Essential.Core.Audio
{
	[Serializable]
	public class ExposedProperty
	{
		[SerializeField] private string _name;
		[SerializeField] private float _volume;

		public string Name => _name;
		
		public float Volume
		{
			get { return _volume; }
			set { _volume = value; }
		}
		
		public ExposedProperty(string name)
		{
			_name = name;
		}
	}
}
