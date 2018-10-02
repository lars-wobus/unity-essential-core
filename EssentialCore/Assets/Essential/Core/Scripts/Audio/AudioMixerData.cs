using System;
using Essential.Core.DataStorage.Json;
using UnityEngine;
using UnityEngine.Audio;

namespace Essential.Core.Audio
{
	[Serializable]
	public class AudioMixerData : ISerializableJson
	{
		[SerializeField] private AudioMixer _audioMixer;
		[SerializeField] private ExposedProperty[] exposedProperties;

		public AudioMixer AudioMixer => _audioMixer;
		public ExposedProperty[] ExposedProperties => exposedProperties;
	
		public string Serialize()
		{
			return JsonUtility.ToJson(this);
		}

		public void Deserialize(string json)
		{
			var obj = JsonUtility.FromJson<AudioMixerData>(json);
			_audioMixer = obj._audioMixer;
			exposedProperties = obj.exposedProperties;
		}
	}
}
