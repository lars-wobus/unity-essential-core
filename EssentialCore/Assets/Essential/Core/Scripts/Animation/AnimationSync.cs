using System.Collections.Generic;
using Essential.Core.Extensions;
using UnityEngine;

namespace Essential.Core.Animation
{
	public class AnimationSync : MonoBehaviour, IStateMachineAnimation
	{
		[SerializeField] private MonoBehaviour[] _components;

		private IEnumerable<MonoBehaviour> Components => _components;
		private IAnimation[] SyncedComponents { get; set; }

		private void Start()
		{
			Initialize();
		}
	
		/// <summary>
		/// Use this for initialization when script is used in any animator state.
		/// In that situation "Awake", "Start", etc. will not be called.
		/// </summary>
		public void Initialize()
		{
			SyncedComponents = Components.FilterByType<IAnimation>();
		}
	
		public void SetProgress(float progress)
		{
			foreach (var animationSync in SyncedComponents)
			{
				animationSync.SetProgress(progress);
			}
		}
	}
}
