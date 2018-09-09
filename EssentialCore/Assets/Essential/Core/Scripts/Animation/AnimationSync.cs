using System.Collections.Generic;
using Essential.Core.Extensions;
using UnityEngine;

namespace Essential.Core.Animation
{
	public class AnimationSync : MonoBehaviour, IAnimation
	{
		[SerializeField] private MonoBehaviour[] _components;

		private IEnumerable<MonoBehaviour> Components => _components;
		private IAnimation[] SyncedComponents { get; set; }

		private void Start()
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
