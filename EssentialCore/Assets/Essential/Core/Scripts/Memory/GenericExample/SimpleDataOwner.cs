using UnityEngine;

namespace Essential.Core.Memory.NonGenericExample
{
    /// <inheritdoc cref="MonoBehaviour" />
    /// <summary>
    /// Example behaviour. Its internal state can be restored by another behaviour. 
    /// </summary>
    public class SimpleDataOwner : MonoBehaviour, IRecoverable<SimpleData>
    {
        /// <summary>
        /// Internal state.
        /// </summary>
        [SerializeField] private SimpleData _simpleData;

        /// <summary>
        /// Get/Set internal state.
        /// </summary>
        public SimpleData Data
        {
            get { return _simpleData; }
            set { _simpleData = value; }
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
