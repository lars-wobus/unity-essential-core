using System;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

namespace Essential.Core.Animation
{
    public class CustomPlayableAnimator : MonoBehaviour
    {
        [SerializeField] private double _duration = 10.0;
        [SerializeField] private AnimationBase[] _animations;
        
        private PlayableGraph _Graph;
        private ScriptPlayable<CustomPlayable> _sourcePlayable;
        
        public double Duration
        {
            get { return _duration; }
            set
            {
                if (value <= 0)
                {
                    return;
                }

                _duration = value;
                OnDurationChanged();
            }
        }

        public CustomPlayable Playable => _sourcePlayable.GetBehaviour();

        private void Awake()
        {
            _Graph = PlayableGraph.Create();

            var animOutput = AnimationPlayableOutput.Create(_Graph, "AnimationOutput", null);

            _sourcePlayable = ScriptPlayable<CustomPlayable>.Create(_Graph, 1);

            animOutput.SetSourcePlayable(_sourcePlayable);

            _sourcePlayable.SetDuration(Duration);
            RegisterAnimations();
        
            _Graph.Play();
        }

        private void OnDestroy()
        {
            // Destroy the graph once done with it.
            _Graph.Destroy();
        }

        private void RegisterAnimations()
        {
            foreach (var animation in _animations)
            {
                if (animation == null)
                {
                    throw new ArgumentNullException("Animation was null");
                }
                Playable.ProgressChanged += animation.SetProgress;
            }
        }

        private void OnDurationChanged()
        {
            _sourcePlayable.SetDuration(Duration);
        }
    }
}