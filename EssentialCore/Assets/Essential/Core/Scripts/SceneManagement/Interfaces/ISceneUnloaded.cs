using System;

namespace Essential.Core.SceneManagement.Interfaces
{
	public interface ISceneUnloaded<T>
	{
		event Action<T> SceneUnloaded;
		void Invoke(T value);
	}
}
