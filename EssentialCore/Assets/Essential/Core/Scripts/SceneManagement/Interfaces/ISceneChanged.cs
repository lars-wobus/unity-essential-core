using System;

namespace Essential.Core.SceneManagement.Interfaces
{
    public interface ISceneChanged<T>
    {
        event Action<T> SceneChanged;
        void Invoke(T value);
    }
}
