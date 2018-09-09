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
		public Registry<IAnimation> Registry { get; set; }
		//private List<IAnimation> Subscribers { get; set; }

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

//		private void Awake()
//		{
//			//Subscribers = new List<IAnimation>();
//		}

		// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
		public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			Progress = stateInfo.normalizedTime % 1f;
		}

//		public void subscribe([notnull] ianimation animation)
//		{
//			/*if (subscribers.any(element => element.equals(animation)))
//			{
//				return;
//			}
//			
//			subscribers.add(animation);*/
//			registry.subscribe(animation);
//		}
//
//		public void unsubscribe(ianimation animation)
//		{
//			//subscribers.remove(animation);
//			registry.unsubscribe(animation);
//		}
//
//		private void notifyobservers()
//		{
//			/*var progress = progress;
//			foreach (var animationsync in subscribers)
//			{
//				animationsync.setprogress(progress);
//			}*/
//			registry.notifyobservers();
//		}

		private void OnProgressChanged()
		{
			//NotifyObservers();
			Registry.NotifyObservers();
		}
	}
}
