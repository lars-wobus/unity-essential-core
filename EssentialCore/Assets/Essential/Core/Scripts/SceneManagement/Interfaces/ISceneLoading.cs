using System;

namespace Essential.Core.SceneManagement.Interfaces
{
	public interface ISceneLoading<T>
	{
		event Action<T, float> SceneLoading;
		void OnSceneLoading(T value, float progress);
	}
}
