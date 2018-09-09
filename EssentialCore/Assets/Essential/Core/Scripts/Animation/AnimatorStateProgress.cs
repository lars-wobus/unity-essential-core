using System.Collections.Generic;
using Essential.Core.Animation;
using UnityEngine;
using System.Linq;

namespace Essential.Core.Animations
{
	public class AnimatorStateProgress : StateMachineBehaviour
	{
		[SerializeField] private MonoBehaviour[] _components;

		private IEnumerable<MonoBehaviour> Components => _components;
		private IAnimation[] SyncedComponents { get; set; }

		public void Awake()
		{
			SyncedComponents = Components
				.Where(element => (element as IAnimation) != null)
				.Select(element => (element as IAnimation)).ToArray();
		}

		// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
		public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			var progress = stateInfo.normalizedTime % 1f;
			foreach (var animationSync in SyncedComponents)
			{
				animationSync.SetProgress(progress);
			}
		}
	}
}
