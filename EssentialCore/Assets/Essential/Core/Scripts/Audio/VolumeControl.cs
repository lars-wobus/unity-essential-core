using System;
using UnityEngine;
using UnityEngine.Audio;

namespace Essential.Core.Audio
{
	public class VolumeControl : MonoBehaviour
	{
		[SerializeField] private AudioMixer _masterMixer;

		private void Start () {
			var parameters = _masterMixer.GetType().GetProperty("exposedParameters").GetValue(_masterMixer, null) as Array;
			foreach (var element in parameters)
			{
				var a = (string)element.GetType().GetField("name").GetValue(element);
				Debug.Log(a);
			}
		}
	}
}
