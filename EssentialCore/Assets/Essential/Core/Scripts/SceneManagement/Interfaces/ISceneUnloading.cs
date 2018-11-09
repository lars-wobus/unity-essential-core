using System;

namespace Essential.Core.SceneManagement.Interfaces
{
	public interface ISceneUnloading<T>
	{
		event Action<T> SceneUnloading;
		void Invoke(T value);
	}
}
