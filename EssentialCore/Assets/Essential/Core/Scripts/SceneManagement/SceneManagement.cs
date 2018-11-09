using System;
using Essential.Core.SceneManagement.Interfaces;
using UnityEngine;

namespace Essential.Core.SceneManagement
{
	public class SceneManagement : MonoBehaviour, ISceneLoad<string>
	{
		public event Action<string, float> SceneLoading;
		public event Action<string> SceneLoaded;
	
		public void OnSceneLoading(string value, float progress)
		{
			SceneLoading?.Invoke(value, progress);
		}

		public void OnSceneLoaded(string value)
		{
			SceneLoaded?.Invoke(value);
		}
	}
}
