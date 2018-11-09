using System.Collections;
using Essential.Core.SceneManagement.Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Essential.Core.SceneManagement
{
	public class SceneHierarchy : MonoBehaviour
	{
		private ISceneLoad<string> SceneLoad { get; set; }

		private void Start()
		{
			SceneLoad = GetComponent<ISceneLoad<string>>();
			if (SceneLoad != null)
			{
				SceneLoad.LoadScene = LoadScene;
				SceneLoad.LoadSceneAsync = LoadSceneInsideCoroutine;
			}
		}
		
		private static bool SceneExists(string sceneName)
		{
			if (Application.CanStreamedLevelBeLoaded(sceneName))
			{
				Debug.LogWarning("Scene does not exist.");
				return false;
			}

			return true;
		}

		private void LoadScene(string sceneName, LoadSceneMode loadSceneMode)
		{
			if (!SceneExists(sceneName))
			{
				SceneLoad?.OnSceneLoadFailure(sceneName);
				return;
			}
			
			SceneLoad?.OnSceneLoading(sceneName, 0.0f);
			SceneManager.LoadScene(sceneName, loadSceneMode);
			SceneLoad?.OnSceneLoading(sceneName, 1.0f);
			SceneLoad?.OnSceneLoaded(sceneName);
		}

		private void LoadSceneInsideCoroutine(string sceneName, LoadSceneMode loadSceneMode)
		{
			StartCoroutine(LoadSceneAsync(sceneName, loadSceneMode));
		}
		
		private IEnumerator LoadSceneAsync(string sceneName, LoadSceneMode loadSceneMode)
		{
			if (!SceneExists(sceneName))
			{
				SceneLoad?.OnSceneLoadFailure(sceneName);
				yield break;
			}
			
			// Note: When one scene was loaded in single mode, then all other scenes loaded in additive mode
			// will wait at 0 progress until the first scene is activated. It is not clear, if a bug returns 0
			// or if they really needs to load afterwards
			
			SceneLoad?.OnSceneLoading(sceneName, 0.0f);
			var asyncOperation = SceneManager.LoadSceneAsync(sceneName, loadSceneMode);
			asyncOperation.allowSceneActivation = false;
			
			while (asyncOperation.progress < 0.9f)
			{
				SceneLoad?.OnSceneLoading(sceneName, asyncOperation.progress);
				yield return null;
			}

			SceneLoad?.OnSceneLoading(sceneName, 1.0f);
			SceneLoad?.OnSceneLoaded(sceneName);
		}
	}
}
