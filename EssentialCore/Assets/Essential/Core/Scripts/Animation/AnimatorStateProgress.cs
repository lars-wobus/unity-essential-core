using System;
using System.Collections.Generic;
using System.Linq;
using Essential.Core.Extensions;
using JetBrains.Annotations;
using UnityEngine;

namespace Essential.Core.Animation
{
	// TODO rename to AnimatorStateProgressObserver or something
	public class AnimatorStateProgress : StateMachineBehaviour
	{
		private List<IAnimation> Subscribers { get; set; }

		private float _progress;
		private float Progress
		{
			get { return _progress; }
			set
			{
				_progress = value;
				OnProgressChanged();
			}
		}

		private void Awake()
		{
			Subscribers = new List<IAnimation>();
		}

		// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
		public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			Progress = stateInfo.normalizedTime % 1f;
		}

		public void Subscribe([NotNull] IAnimation animation)
		{
			if (Subscribers.Any(element => element.Equals(animation)))
			{
				return;
			}
			
			Subscribers.Add(animation);
		}

		public void Unsubscribe(IAnimation animation)
		{
			Subscribers.Remove(animation);
		}

		private void NotifyObservers()
		{
			var progress = Progress;
			foreach (var animationSync in Subscribers)
			{
				animationSync.SetProgress(progress);
			}
		}

		private void OnProgressChanged()
		{
			NotifyObservers();
		}
	}
}
