using Essential.Core.Animation.Data;
using UnityEngine;
using _Scripts.Math;

namespace Essential.Core.Animation
{
    /// <inheritdoc />
    /// <summary>
    /// Animate rotation around GameObject's pivot point.
    /// </summary>
    public class ContinuousRotation : AnimationBase
    {
        [SerializeField] private RotationData _rotationData;
        
        /// <summary>
        /// Store for the Prefab property.
        /// </summary>
        [SerializeField] private Transform _transform;
        
        protected override void Start()
        {
            Animation = new Classes.RotationAnimator(_rotationData, _transform);
        }
    }
}