using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Essential.Core.Utils
{	
	public class SceneDirector : MonoBehaviour
	{
		[SerializeField] private UnityScene[] _scenes;
		[SerializeField] private UnityEvent _sceneLoaded;
		private IProgressHandler ProgressHandler { get; set; }

		private void Start()
		{
			ProgressHandler = GetComponent<IProgressHandler>();
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

		private IEnumerator LoadSceneByNameAsync(UnityScene scene)
		{
			scene.AsyncOperation = SceneManager.LoadSceneAsync(scene.SceneName, scene.LoadSceneMode);
			
			while (!scene.AsyncOperation.isDone)
			{
				ProgressHandler?.OnProgressChanged(scene.AsyncOperation.progress);
			}
			
			scene.AsyncOperation.allowSceneActivation = false;
			
			_sceneLoaded.Invoke();
			yield return null;
		}

		private UnityScene FindScene(int sceneIndex)
		{
			if (sceneIndex < 0 || sceneIndex >= _scenes.Length)
			{
				throw new ArgumentOutOfRangeException(nameof(sceneIndex));
			}
			
			return _scenes[sceneIndex];
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