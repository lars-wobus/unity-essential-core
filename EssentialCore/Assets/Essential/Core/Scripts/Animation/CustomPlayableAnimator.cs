using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

namespace Essential.Core.Animation
{
    [RequireComponent(typeof(Animator))]
    public class CustomPlayableAnimator : MonoBehaviour
    {
        private PlayableGraph _Graph;
        private ScriptPlayable<CustomPlayable> _sourcePlayable;

        public double Duration
        {
            get { return _sourcePlayable.GetDuration(); }
            set
            {
                if (value < 0)
                {
                    return;
                }
                
                _sourcePlayable.SetDuration(value);
            }
        }
    
        void Start()
        {
            _Graph = PlayableGraph.Create();

            var animOutput = AnimationPlayableOutput.Create(_Graph, "AnimationOutput", GetComponent<Animator>());

            _sourcePlayable = ScriptPlayable<CustomPlayable>.Create(_Graph, 1);

            animOutput.SetSourcePlayable(_sourcePlayable);
        
            _Graph.Play();
        }

        private void OnDestroy()
        {
            // Destroy the graph once done with it.
            _Graph.Destroy();
        }
    }
}