using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

public class BlenderPlayableBehaviour : PlayableBehaviour
{
    private float _time;
    private float Time
    {
        get { return _time; }
        set
        {
            _time = value;
            Debug.Log(value.ToString());
        }
    }

    public override void PrepareFrame(Playable playable, FrameData info)
    {
        Time += info.deltaTime;
        Debug.Log(playable.GetTime().ToString()+" "+playable.GetDuration().ToString());
    }
    
    public override void OnGraphStart(Playable playable)
    {
        Debug.Log("OnGraphStart");
    }

    // Called when the owning graph stops playing
    public override void OnGraphStop(Playable playable) {
        Debug.Log("OnGraphStop");
    }

    // Called when the state of the playable is set to Play
    public override void OnBehaviourPlay(Playable playable, FrameData info)
    {
        Debug.Log("OnBehaviourPlay");
    }

    // Called when the state of the playable is set to Paused
    public override void OnBehaviourPause(Playable playable, FrameData info) {
        Debug.Log("OnBehaviourPause");
    }
}

public class PlayableBehaviourSample : MonoBehaviour
{
    PlayableGraph m_Graph;
    
    void Start()
    {
        m_Graph = PlayableGraph.Create();

        var animOutput = AnimationPlayableOutput.Create(m_Graph, "AnimationOutput", GetComponent<Animator>());

        var blenderPlayable = ScriptPlayable<BlenderPlayableBehaviour>.Create(m_Graph, 1);

        animOutput.SetSourcePlayable(blenderPlayable);
        
        m_Graph.Play();
    }

    private void OnDestroy()
    {
        // Destroy the graph once done with it.
        m_Graph.Destroy();
    }
}