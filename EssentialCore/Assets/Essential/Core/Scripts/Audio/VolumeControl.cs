using System;
using System.Diagnostics;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;

namespace Essential.Core.Audio
{
	public class VolumeControl : MonoBehaviour
	{
		[SerializeField] private AudioMixer _masterMixer;
		[SerializeField] private ExposedPropertyData _customSettings; // used in custom inspector
		[SerializeField] private ExposedProperty[] _exposedProperty;

		[Conditional("UNITY_EDITOR")]
		private void Start()
		{
			if (_exposedProperty.GroupBy(x => x.Name).Any(g => g.Count() > 1))
			{
				throw new ArgumentException("Found duplicates of exposed property");
			}

			LoadCustomSettings();
		}

		private void LoadCustomSettings()
		{
			throw new NotImplementedException();
		}

		private void SaveCustomSettings()
		{
			throw new NotImplementedException();
		}
		
		public void SetVolume(string searchName, float value)
		{
			if (string.IsNullOrEmpty(searchName))
			{
				throw new ArgumentException("Value cannot be null or empty.", nameof(searchName));
			}

			var exposedProperty = _exposedProperty.FirstOrDefault(element => element.Name == searchName);
			if(exposedProperty == null)
			{
				throw new ArgumentException("No exposed property found.", searchName);
			}

			exposedProperty.Volume = value;
			_masterMixer.SetFloat(searchName, value);
		}

		public float GetVolume(string searchName)
		{
			float value;
			if (!_masterMixer.GetFloat(searchName, out value))
			{
				throw new ArgumentException("No exposed property found.", searchName);
			}

			return value;
		}

		private void OnApplicationQuit()
		{
			SaveCustomSettings();
		}
	}
}
