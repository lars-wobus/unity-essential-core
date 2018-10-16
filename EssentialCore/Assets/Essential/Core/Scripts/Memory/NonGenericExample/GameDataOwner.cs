﻿using UnityEngine;

namespace Essential.Core.Memory.NonGenericExample
{
    /// <inheritdoc cref="MonoBehaviour" />
    /// <summary>
    /// Example behaviour. Its internal state can be restored by another behaviour. 
    /// </summary>
    public class GameDataOwner : MonoBehaviour, IRecoverable<GameData>
    {
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
            Data.Index++;
        }
    }
}
