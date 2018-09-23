using System;
using UnityEngine;

namespace Essential.Core.Audio
{
	[CreateAssetMenu(fileName = "ExposedPropertyItem", menuName = "Essential/Audio/ExposedPropertyItem", order = 1)]
	public class ExposedPropertyData : ScriptableObject
	{
		[SerializeField] private ExposedProperty[] _exposedProperties;

		public ExposedProperty[] ExposedProperties
		{
			get { return _exposedProperties; }
			set { _exposedProperties = value; }
		}
	}
}
