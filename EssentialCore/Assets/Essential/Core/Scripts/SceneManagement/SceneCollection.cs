using System.Collections.Generic;
using UnityEngine;

namespace Essential.Core.SceneManagement
{
    public class SceneCollection : MonoBehaviour
    {
        [SerializeField] private SceneConfiguration[] _scenesConfigurations;

        public SceneConfiguration[] SceneConfigurations
        {
            get { return _scenesConfigurations; }
            set { _scenesConfigurations = value; }
        }
    }
}
