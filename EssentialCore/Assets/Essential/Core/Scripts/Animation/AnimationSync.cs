using System.Collections.Generic;
using Essential.Core.Extensions;
using UnityEngine;

namespace Essential.Core.Animation
{
	/// <summary>
	/// Sync progress for multiple animations at once.
	/// </summary>
	public class AnimationSync : AnimationBase
	{
		/// <summary>
		/// Persistent collection of animations.
		/// </summary>
		[SerializeField] private AnimationBase[] _animations;
		
		/// <inheritdoc cref="IAnimation.SetProgress"/>
		public override void SetProgress(double progress)
		{
			foreach (var animatonBehaviour in _animations)
			{
				animatonBehaviour.SetProgress(progress);
			}
		}
	}
}
