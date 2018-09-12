using System;
using UnityEngine;
using UnityEngine.Playables;

namespace Essential.Core.Animation
{
	public class CustomPlayable : PlayableBehaviour
	{
		public event Action GraphStarted;
		public event Action GraphStopped;
		public event Action BehaviourPlayed;
		public event Action BehaviourPaused;
		public event Action<double> ProgressChanged;
		
		// Called when the owning graph starts playing
		public override void OnGraphStart(Playable playable)
		{
			Debug.Log("OnGraphStart");
			GraphStarted?.Invoke();
		}

		// Called when the owning graph stops playing
		public override void OnGraphStop(Playable playable) {
			Debug.Log("OnGraphStop");
			GraphStopped?.Invoke();
		}

		// Called when the state of the playable is set to Play
		public override void OnBehaviourPlay(Playable playable, FrameData info) {
			Debug.Log("OnBehaviourPlay");
			BehaviourPlayed?.Invoke();
		}

		// Called when the state of the playable is set to Paused
		public override void OnBehaviourPause(Playable playable, FrameData info) {
			Debug.Log("OnBehaviourPause");
			BehaviourPaused?.Invoke();
		}

		// Called each frame while the state is set to Play
		public override void PrepareFrame(Playable playable, FrameData info) {
			Debug.Log($"PrepareFrame {playable.GetTime().ToString()} {playable.GetDuration().ToString()}");
			ProgressChanged?.Invoke(playable.GetTime() / playable.GetDuration());
		}
	}
}
