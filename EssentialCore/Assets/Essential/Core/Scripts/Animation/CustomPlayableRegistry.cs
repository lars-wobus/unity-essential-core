using UnityEngine;

namespace Essential.Core.Animation
{
	[RequireComponent(typeof(CustomPlayableAnimator))]
	public class CustomPlayableRegistry : MonoBehaviour
	{
		private CustomPlayableAnimator _customPlayable;
		
		private void Start ()
		{
			_customPlayable = GetComponent<CustomPlayableAnimator>();
			_customPlayable.Duration = 10;
			_customPlayable.Playable.ProgressChanged += GetComponent<AnimationSync>().SetProgress;
		}
	}
}
