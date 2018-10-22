using System;
using Essential.Core.Event.Interfaces;
using UnityEngine;
using UnityEngine.Events;

namespace Essential.Core.Scripts.Event.UnityEventProvider
{
	[Serializable]
	public class FloatEvent : UnityEvent<float> {}
	
	public class DownloadEventProvider : MonoBehaviour, IDownloadHandler
	{
		public FloatEvent ProgressChanged;
		public UnityEvent DownloadComplete;
		
		public void OnProgressChanged(float value)
		{
			ProgressChanged?.Invoke(value);
		}

		public void OnComplete()
		{
			DownloadComplete?.Invoke();
		}
	}
}
