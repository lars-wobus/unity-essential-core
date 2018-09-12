using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

namespace Essential.Core.Animation
{
    [RequireComponent(typeof(Animator))]
    public class CustomPlayableAnimator : MonoBehaviour
    {
        private PlayableGraph m_Graph;
    
        void Start()
        {
            m_Graph = PlayableGraph.Create();

            var animOutput = AnimationPlayableOutput.Create(m_Graph, "AnimationOutput", GetComponent<Animator>());

            var blenderPlayable = ScriptPlayable<CustomPlayable>.Create(m_Graph, 1);

            animOutput.SetSourcePlayable(blenderPlayable);
        
            m_Graph.Play();
        }

        private void OnDestroy()
        {
            // Destroy the graph once done with it.
            m_Graph.Destroy();
        }
    }
}