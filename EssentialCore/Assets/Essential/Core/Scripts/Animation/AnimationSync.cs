using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Essential.Core.Animation;

public class AnimationSync : MonoBehaviour
{
	[SerializeField] private Component[] _components;
	[SerializeField] private List<ISync> _syncedComponents;

	public Component[] Components
	{
		get { return _components; }
		set { _components = value; }
	}

	// Use this for initialization
	void Start ()
	{
		_syncedComponents = new List<ISync>();
		foreach (var component in Components)
		{
			_syncedComponents.Add(component as ISync);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		var deltaTime = Time.deltaTime;
		_syncedComponents.ForEach(element => element.HandleUpdate());
		
	}
}
