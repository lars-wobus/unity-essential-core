using UnityEngine;

namespace Essential.Core.Animation
{
    public abstract class AnimationBase : MonoBehaviour, IAnimation
    {
        public abstract void SetProgress(float progress);
        public abstract void SetProgress(double progress);
    }
}
