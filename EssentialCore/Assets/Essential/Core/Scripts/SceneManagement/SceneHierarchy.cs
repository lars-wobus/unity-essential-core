﻿using System.Collections;
using Essential.Core.Event.Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Essential.Core.SceneManagement
{
	public class SceneHierarchy : MonoBehaviour
	{
		private IDownloadHandler EventHandler;

		private void Start()
		{
			EventHandler = GetComponent<IDownloadHandler>();
		}
		
		public static bool SceneExists(string sceneName)
		{
			if (Application.CanStreamedLevelBeLoaded(sceneName)) return true;
			Debug.LogWarning("Scene does not exist.");
			return false;
		}
		
		public void LoadSceneSingle(string sceneName)
		{
			LoadScene(sceneName, LoadSceneMode.Single);
		}
		
		public void LoadSceneAdditive(string sceneName)
		{
			LoadScene(sceneName, LoadSceneMode.Additive);
		}

		private void LoadScene(string sceneName, LoadSceneMode loadSceneMode)
		{
			if (!SceneExists(sceneName)) return;
			SceneManager.LoadScene(sceneName, loadSceneMode);
			EventHandler?.OnComplete();
		}
		
		public void LoadSceneSingleAsync(string sceneName)
		{
			StartCoroutine(LoadSceneAsync(sceneName, LoadSceneMode.Single));
		}
		
		public void LoadSceneAdditiveAsync(string sceneName)
		{
			StartCoroutine(LoadSceneAsync(sceneName, LoadSceneMode.Additive));
		}
		
		private IEnumerator LoadSceneAsync(string sceneName, LoadSceneMode loadSceneMode)
		{
			if (!SceneExists(sceneName))
			{
				yield break;
			}
			
			var asyncOperation = SceneManager.LoadSceneAsync(sceneName, loadSceneMode);
			asyncOperation.allowSceneActivation = false;
			
			while (asyncOperation.progress < 0.9f)
			{
				EventHandler?.OnProgressChanged(asyncOperation.progress);
				yield return null;
			}

			EventHandler?.OnProgressChanged(1.0f);
			EventHandler?.OnComplete();
		}
	}
}
