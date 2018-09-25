using UnityEngine;

namespace Essential.Core.Audio
{
	public class AudioMixerDataComponent : MonoBehaviour
	{
		[SerializeField] private AudioMixerData _data;

		public AudioMixerData Data => _data;

		private void Start()
		{
			Debug.Log(_data.SerializeToJson());
			LoadCustomSettings();
		}
		
		private void LoadCustomSettings()
		{
			string json = "{\"_audioMixer\":{\"instanceID\":3122},\"exposedProperties\":[{\"_name\":\"b\",\"_volume\":1.0}]}";
			// TODO read json from local storage or get data from server
			_data.Deserialize(json);
		}

		private void SaveCustomSettings()
		{
			Debug.Log(_data.SerializeToJson());
			// TODO write json to local storage or send data to server
		}
		
		private void OnApplicationQuit()
		{
			SaveCustomSettings();
		}
	}
}
