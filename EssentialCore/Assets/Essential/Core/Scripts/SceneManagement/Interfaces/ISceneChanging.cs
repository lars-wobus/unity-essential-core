using System;

namespace Essential.Core.SceneManagement.Interfaces
{
	public interface ISceneChanging<T>
	{
		event Action<T> SceneChanging;
		void Invoke(T value);
	}
}
