using UnityEngine;

namespace Essential.Core.SceneManagement
{
    public class SceneCollection : ScriptableObject
    {
        [SerializeField] private SceneConfiguration[] _scenesConfigurations;

        public SceneConfiguration[] SceneConfigurations
        {
            get { return _scenesConfigurations; }
            set { _scenesConfigurations = value; }
        }
    }
}
