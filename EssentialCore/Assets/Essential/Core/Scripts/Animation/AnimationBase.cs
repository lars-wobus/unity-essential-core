using UnityEngine;

namespace Essential.Core.Animation
{
    /// <summary>
    /// Allows serialization for all kinds of animations, which means one can link them via the inspector.
    /// </summary>
    public abstract class AnimationBase : MonoBehaviour, IAnimation
    {
        /// <inheritdoc cref="IAnimation.SetProgress"/>
        public abstract void SetProgress(double progress);
    }
}
