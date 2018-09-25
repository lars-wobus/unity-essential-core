using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;

namespace Essential.Core.Audio
{
	[RequireComponent(typeof(AudioMixerDataComponent))]
	public class AudioMixerWrapper : MonoBehaviour
	{
		private AudioMixer AudioMixer { get; set; }
		private ExposedProperty[] ExposedProperties { get; set; }

		public void Start()
		{
			var component = GetComponent<AudioMixerDataComponent>();
			AudioMixer = component.Data.AudioMixer;
			ExposedProperties = component.Data.ExposedProperties;
		}

		public void SetFloat(string searchName, float value)
		{
			if (string.IsNullOrEmpty(searchName))
			{
				throw new ArgumentException("Value cannot be null or empty.", nameof(searchName));
			}

			var exposedProperty = ExposedProperties.FirstOrDefault(element => element.Name == searchName);
			if(exposedProperty == null)
			{
				throw new ArgumentException("No exposed property found.", searchName);
			}

			exposedProperty.Volume = value;
			AudioMixer.SetFloat(searchName, value);
		}

		public float GetFloat(string searchName)
		{
			float value;
			if (!AudioMixer.GetFloat(searchName, out value))
			{
				throw new ArgumentException("No exposed property found.", searchName);
			}

			return value;
		}
	}
}
