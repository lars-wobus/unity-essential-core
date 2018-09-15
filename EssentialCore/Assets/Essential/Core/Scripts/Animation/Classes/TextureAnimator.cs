using UnityEngine;

namespace Essential.Core.Animation.Classes
{
    public abstract class TextureAnimator : IAnimation
    {
        protected Vector2 DefaultValue { get; set; }
        
        public abstract void HandleProgressChange(float progress);

        public void HandleApplicationQuit()
        {
            HandleProgressChange(0);
        }
    }
}
