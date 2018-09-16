using System.Collections.Generic;
using UnityEngine;

namespace Essential.Core.Development
{
	[CreateAssetMenu(fileName = "Registry_", menuName = "Development/Registry", order = 1)]
	public class Registry : ScriptableObject
	{
		[SerializeField] private List<GameObject> _subscribers;

		public void Register(GameObject gameObject)
		{
			_subscribers.Add(gameObject);
		}
		
		public void Unregister(GameObject gameObject)
		{
			//_subscribers.Remove(gameObject);
		}
	}
}
