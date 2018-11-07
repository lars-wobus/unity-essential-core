using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Essential.Core.SceneManagement
{
	public class SceneHierarchy : MonoBehaviour
	{		
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
			if (SceneExists(sceneName))
			{
				SceneManager.LoadScene(sceneName, loadSceneMode);
			}
		}
		
		public void LoadSceneSingleAsync(string sceneName)
		{
			StartCoroutine(LoadSceneAsync(sceneName, LoadSceneMode.Single));
		}
		
		public void LoadSceneAdditiveAsync(string sceneName)
		{
			StartCoroutine(LoadSceneAsync(sceneName, LoadSceneMode.Additive));
		}
		
		private static IEnumerator LoadSceneAsync(string sceneName, LoadSceneMode loadSceneMode)
		{
			if (!SceneExists(sceneName))
			{
				yield break;
			}
			
			var asyncLoad = SceneManager.LoadSceneAsync(sceneName, loadSceneMode);
			asyncLoad.allowSceneActivation = false;
		
			//_asyncOperations.Add(asyncLoad);
			//_onLoadFinished.Invoke();
			yield return null;
		}
	}
}
