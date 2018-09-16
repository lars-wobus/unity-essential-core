using UnityEngine;

namespace Essential.Core.Development
{
	public class Subscriber : MonoBehaviour
	{
		[SerializeField] private Registry _registry;
		[SerializeField] private Factory _factory;

		private void Start () {
			_registry.Register(gameObject);
			_factory.Instantiate();
		}

		private void OnApplicationQuit()
		{
			_registry.Unregister(gameObject);
		}
	}
}
