using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Essential.Core.Development
{
	[CreateAssetMenu(fileName = "Factory_", menuName = "Development/Factory", order = 1)]
	public class Factory : ScriptableObject
	{
		[SerializeField] private List<GameObject> _prefabs;
		[SerializeField] private GameObject _parent;

		public void Instantiate()
		{
			_parent = GameObject.Find("_Dynamic");
			Instantiate(_prefabs.ElementAt(0), _parent.transform);
		}
	}
}
