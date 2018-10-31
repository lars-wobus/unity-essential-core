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
		[SerializeField] private bool _enabledInBuildSettings;
		[SerializeField] private string _path;

		public string SceneName
		{
			get
			{
				return _sceneName;
			}
			set
			{
				_sceneName = value;
			}
		}

		public LoadSceneMode LoadSceneMode => _loadSceneMode;
		public UpdateProgress LoadProgress => _loadProgress;
		public AsyncOperation AsyncOperation { get; set; }

		public bool EnabledInBuildSettings
		{
			get
			{
				return _enabledInBuildSettings;
			}
			set
			{
				_enabledInBuildSettings = value;
			}
		}
		
		public string Path
		{
			get
			{
				return _path;
			}
			set
			{
				_path = value;
			}
		}
	}
}
