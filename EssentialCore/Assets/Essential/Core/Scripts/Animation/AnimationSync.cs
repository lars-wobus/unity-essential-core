using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Essential.Core.Animation;

public class AnimationSync : MonoBehaviour, IAnimation
{
	[SerializeField] private Component[] _components;
	[SerializeField] private List<IAnimation> _syncedComponents;

	public List<IAnimation> SyncedComponents
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
		_syncedComponents = new List<IAnimation>();
		foreach (var component in Components)
		{
			_syncedComponents.Add(component as IAnimation);
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
