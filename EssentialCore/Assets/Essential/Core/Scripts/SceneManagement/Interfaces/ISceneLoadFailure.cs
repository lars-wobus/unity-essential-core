using System;

namespace Essential.Core.SceneManagement.Interfaces
{
    public interface ISceneLoadFailure<T>
    {
        event Action<T> SceneLoadFailure;
        void OnSceneLoadFailure(T value);
    }
}