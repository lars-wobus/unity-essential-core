using System;
using Essential.Core.SceneManagement.Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Essential.Core.SceneManagement
{
	// TODO right now this class is an event handler and trigger at the same time
	public class SceneManagement : MonoBehaviour, ISceneLoad<string>
	{
		public event Action<string, float> SceneLoading;
		public event Action<string> SceneLoaded;
		public event Action<string> SceneLoadFailure;
		
		public void OnSceneLoading(string value, float progress)
		{
			SceneLoading?.Invoke(value, progress);
		}

		public void OnSceneLoaded(string value)
		{
			SceneLoaded?.Invoke(value);
		}
		
		public void OnSceneLoadFailure(string value)
		{
			SceneLoadFailure?.Invoke(value);
		}

		public Action<string, LoadSceneMode> LoadScene { get; set; }
		public Action<string, LoadSceneMode> LoadSceneAsync { get; set; }
		
		public void LoadSceneSingle(string sceneName)
		{
			LoadScene?.Invoke(sceneName, LoadSceneMode.Single);
		}
		
		public void LoadSceneAdditive(string sceneName)
		{
			LoadScene?.Invoke(sceneName, LoadSceneMode.Additive);
		}
		
		public void LoadSceneSingleAsync(string sceneName)
		{
			LoadSceneAsync?.Invoke(sceneName, LoadSceneMode.Single);
		}
		
		public void LoadSceneAdditiveAsync(string sceneName)
		{
			LoadSceneAsync?.Invoke(sceneName, LoadSceneMode.Additive);
		}
	}
}
