using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Essential.Core.Animation;

public class AnimationProgress : MonoBehaviour, IAnimationProgress
{
	[SerializeField] private Component[] _components;
	[SerializeField] private List<IAnimationProgress> _syncedComponents;

	public List<IAnimationProgress> SyncedComponents
	{
		get { return _syncedComponents; }
		set { _syncedComponents = value; }
	}

	public Component[] Components
	{
		get { return _components; }
		set { _components = value; }
	}

	// Use this for initialization
	void Start ()
	{
		_syncedComponents = new List<IAnimationProgress>();
		foreach (var component in Components)
		{
			_syncedComponents.Add(component as IAnimationProgress);
		}
	}
	
	public void SetProgress(float deltaTime)
	{
		if (_syncedComponents == null)
		{
			Debug.Log("Not initialized");
			Start();
			return;
		}
		_syncedComponents.ForEach(element => element.SetProgress(deltaTime));
	}
}
