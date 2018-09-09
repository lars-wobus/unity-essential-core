using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Essential.Core.Animation;
using Essential.Core.Extensions;

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
	
	public void SetProgress(float deltaTime)
	{
		Debug.Log(SyncedComponents);
		if (SyncedComponents == null)
		{
			Debug.Log(_components.Length.ToString());
			Debug.Log("Not initialized");
			return;
		}

		foreach (var animationSync in SyncedComponents)
		{
			animationSync.SetProgress(deltaTime);
		}
	}
}
