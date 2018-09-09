using System.Collections.Generic;
using Essential.Core.Extensions;
using UnityEngine;

namespace Essential.Core.Animation
{
	public class AnimatorStateRegistry : MonoBehaviour {

		[SerializeField] private MonoBehaviour[] _components;
	
		private IEnumerable<MonoBehaviour> Components => _components;
		private AnimatorStateProgress AnimatorStateProgress { get; set; }
	
		// Use this for initialization
		void Start ()
		{
			var animator = GetComponent<Animator>();
			AnimatorStateProgress = animator.GetBehaviour<AnimatorStateProgress>();
			AnimatorStateProgress.Registry = new Registry<IAnimation>();
			
			var animations = Components.FilterByType<IAnimation>();
			foreach (var anim in animations)
			{
				Register(anim);
			}
		}

		public void Register(IAnimation anim)
		{
			//AnimatorStateProgress.Subscribe(anim);
			AnimatorStateProgress.Registry.Subscribe(anim);
		}
		
		public void Unregister(IAnimation anim)
		{
			//AnimatorStateProgress.Unsubscribe(anim);
			AnimatorStateProgress.Registry.Unsubscribe(anim);
		}
	}
}
