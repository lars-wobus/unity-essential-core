using System;

namespace Rapid.Animation
{
    [Obsolete]
    public interface IAnimationPlayer
    {
        void Start();
        void Stop();
        void Continue();
        void Pause();
    }
}