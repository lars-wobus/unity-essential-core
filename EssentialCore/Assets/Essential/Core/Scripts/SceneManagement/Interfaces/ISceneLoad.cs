using System;
using UnityEngine.SceneManagement;

namespace Essential.Core.SceneManagement.Interfaces
{
    public interface ISceneLoad<T> : ISceneLoading<T>, ISceneLoaded<T>, ISceneLoadFailure<T>
    {
        Action<T, LoadSceneMode> LoadScene { get; set; }
        Action<T, LoadSceneMode> LoadSceneAsync { get; set; }
        //void OnSceneLoading(T value, float progress);
        
        /*void LoadSceneSingle(string sceneName);
        void LoadSceneAdditive(string sceneName);
        void LoadSceneSingleAsync(string sceneName);
        void LoadSceneAdditiveAsync(string sceneName);*/
    }
}