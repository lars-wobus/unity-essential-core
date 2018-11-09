using System;

namespace Essential.Core.SceneManagement.Interfaces
{
	public interface ISceneLoading<T1>
	{
		event Action<T1, float> SceneLoading;
		void OnSceneLoading(T1 value1, float progress);
	}
}
