using System;

namespace Essential.Core.SceneManagement.Interfaces
{
	public interface ISceneLoaded<T>
	{
		event Action<T> SceneLoaded;
		void OnSceneLoaded(T value);
	}
}
