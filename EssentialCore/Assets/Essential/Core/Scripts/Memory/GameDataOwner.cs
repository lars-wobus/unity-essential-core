using System;
using UnityEngine;

namespace Essential.Core.Memory
{
    /// <summary>
    /// Example behaviour. Its internal state can be restored by another behaviour. 
    /// </summary>
    public class GameDataOwner : MonoBehaviour
    {
        /// <summary>
        /// Specifies the internal state of behavioural classes.
        /// </summary>
        [Serializable]
        public class Data
        {
            public int a;
        }

        /// <summary>
        /// Internal state.
        /// </summary>
        [SerializeField] private Data _data;

        /// <summary>
        /// Get/Set internal state.
        /// </summary>
        public Data Data2
        {
            get { return _data; }
            set { _data = value; }
        }

        /// <summary>
        /// Update is used to constantly modify own state. 
        /// </summary>
        public void Update()
        {
            _data.a++;
        }
    }
}
