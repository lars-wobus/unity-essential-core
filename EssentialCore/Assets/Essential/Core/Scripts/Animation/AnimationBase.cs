﻿using Essential.Core.Animation.Data;
using UnityEngine;

namespace Essential.Core.Animation
{
    /// <inheritdoc />
    /// <summary>
    /// Allows serialization for all kinds of animations, which means one can link them via the inspector.
    /// </summary>
    public abstract class AnimationBase : MonoBehaviour, IAnimation
    {
        protected Classes.IAnimation Animation { private get; set; }

        protected abstract void Start();
        
        public void SetProgress(double progress)
        {
            Animation.HandleProgressChange((float)progress);
        }

        private void OnApplicationQuit()
        {
            Animation.HandleApplicationQuit();
        }
    }
}
