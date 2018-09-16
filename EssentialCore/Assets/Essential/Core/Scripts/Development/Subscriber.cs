using UnityEngine;

namespace Essential.Core.Development
{
	public class Subscriber : MonoBehaviour
	{
		[SerializeField] private Registry _registry;

		private void Start () {
			_registry.Register(gameObject);
		}

		private void OnApplicationQuit()
		{
			_registry.Unregister(gameObject);
		}
	}
}
