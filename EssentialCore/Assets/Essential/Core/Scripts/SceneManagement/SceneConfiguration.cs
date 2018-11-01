﻿using System;
using Essential.Core.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Essential.Core.SceneManagement
{
	[Serializable]
	public class SceneConfiguration
	{
		[SerializeField] private string _sceneName;
		[SerializeField] private string _path;
		[SerializeField] private LoadSceneMode _loadSceneMode;
		[SerializeField] private UpdateProgress _loadProgress;
		[SerializeField] private bool _enabledInBuildSettings;
		[SerializeField] private bool _allowSceneActivation;
		
		public string SceneName
		{
			get { return _sceneName; }
			set { _sceneName = value; }
		}
		
		public string Path
		{
			get { return _path; }
			set { _path = value; }
		}

		public LoadSceneMode LoadSceneMode => _loadSceneMode;
		public UpdateProgress LoadProgress => _loadProgress;
		public AsyncOperation AsyncOperation { get; set; }

		public bool EnabledInBuildSettings
		{
			get { return _enabledInBuildSettings; }
			set { _enabledInBuildSettings = value; }
		}

		public bool AllowSceneActivation
		{
			get { return _allowSceneActivation; }
			set { _allowSceneActivation = value; }
		}
		
	}
}