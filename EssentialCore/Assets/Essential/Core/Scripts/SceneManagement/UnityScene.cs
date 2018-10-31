using System;
using Essential.Core.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Essential.Core.SceneManagement
{
	[Serializable]
	public class UnityScene
	{
		[SerializeField] private string _sceneName;
		[SerializeField] private LoadSceneMode _loadSceneMode;
		[SerializeField] private UpdateProgress _loadProgress;

		public string SceneName => _sceneName;
		public LoadSceneMode LoadSceneMode => _loadSceneMode;
		public UpdateProgress LoadProgress => _loadProgress;
		public AsyncOperation AsyncOperation { get; set; }
	}
}
