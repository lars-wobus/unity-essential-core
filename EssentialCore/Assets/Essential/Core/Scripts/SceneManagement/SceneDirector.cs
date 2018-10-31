using System;
using System.Collections;
using Essential.Core.Event.Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Essential.Core.SceneManagement
{	
	public class SceneDirector : MonoBehaviour
	{
		[SerializeField] private SceneConfiguration[] _scenesConfiguration;
		private IDownloadHandler EventHandler { get; set; }

		private void Start()
		{
			EventHandler = GetComponent<IDownloadHandler>();
		}
		
		public void StartLoadingSceneReferencedInCollection(int sceneIndex)
		{
			var scene = FindScene(sceneIndex);

			if (scene.AsyncOperation != null)
			{
				throw new NotSupportedException("Loading scene has already begun: " + scene.SceneName);
			}

			StartCoroutine(LoadSceneByNameAsync(scene));
		}

		private IEnumerator LoadSceneByNameAsync(SceneConfiguration sceneConfiguration)
		{
			sceneConfiguration.AsyncOperation = SceneManager.LoadSceneAsync(sceneConfiguration.SceneName, sceneConfiguration.LoadSceneMode);
			
			while (!sceneConfiguration.AsyncOperation.isDone)
			{
				EventHandler?.OnProgressChanged(sceneConfiguration.AsyncOperation.progress);
				yield return null;
			}
			
			sceneConfiguration.AsyncOperation.allowSceneActivation = false;
			
			EventHandler?.OnComplete();
		}

		private SceneConfiguration FindScene(int sceneIndex)
		{
			if (sceneIndex < 0 || sceneIndex >= _scenesConfiguration.Length)
			{
				throw new ArgumentOutOfRangeException(nameof(sceneIndex));
			}
			
			return _scenesConfiguration[sceneIndex];
		}

		public void FinalizeSceneLoading(int sceneIndex)
		{
			var scene = FindScene(sceneIndex);
			if (scene == null)
			{
				return;
			}

			ActivateScene(scene.AsyncOperation);
			scene.AsyncOperation = null;
		}

		private static void ActivateScene(AsyncOperation asyncOperation)
		{
			if (asyncOperation == null)
			{
				return;
			}
			
			asyncOperation.allowSceneActivation = true;
		}
	}
}