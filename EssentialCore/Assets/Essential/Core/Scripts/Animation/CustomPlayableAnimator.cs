using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

namespace Essential.Core.Animation
{
    [RequireComponent(typeof(Animator))]
    public class CustomPlayableAnimator : MonoBehaviour
    {
        private PlayableGraph m_Graph;
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
            m_Graph = PlayableGraph.Create();

            var animOutput = AnimationPlayableOutput.Create(m_Graph, "AnimationOutput", GetComponent<Animator>());

            _sourcePlayable = ScriptPlayable<CustomPlayable>.Create(m_Graph, 1);

            animOutput.SetSourcePlayable(_sourcePlayable);
        
            m_Graph.Play();
        }

        private void OnDestroy()
        {
            // Destroy the graph once done with it.
            m_Graph.Destroy();
        }
    }
}