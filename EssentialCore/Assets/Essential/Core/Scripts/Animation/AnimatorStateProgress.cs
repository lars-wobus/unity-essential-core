using System.Collections.Generic;
using Essential.Core.Extensions;
using UnityEngine;

namespace Essential.Core.Animation
{
	public class AnimatorStateProgress : StateMachineBehaviour
	{
		[SerializeField] private MonoBehaviour[] _components;

		private IEnumerable<MonoBehaviour> Components => _components;
		private IStateMachineAnimation[] SyncedComponents { get; set; }

		public void Awake()
		{
			SyncedComponents = Components.FilterByType<IStateMachineAnimation>();
			foreach (var syncedComponent in SyncedComponents)
			{
				syncedComponent.Initialize();
			}
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
