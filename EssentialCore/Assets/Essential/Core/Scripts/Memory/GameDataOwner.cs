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
        public class GameData
        {
            public int _index;
        }

        /// <summary>
        /// Internal state.
        /// </summary>
        [SerializeField] private GameData _gameData;

        /// <summary>
        /// Get/Set internal state.
        /// </summary>
        public GameData Data
        {
            get { return _gameData; }
            set { _gameData = value; }
        }

        /// <summary>
        /// Update is used to constantly modify own state. 
        /// </summary>
        public void Update()
        {
            Data._index++;
        }
    }
}
