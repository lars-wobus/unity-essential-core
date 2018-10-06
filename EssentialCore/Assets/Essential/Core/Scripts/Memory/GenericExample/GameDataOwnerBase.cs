using UnityEngine;

namespace Essential.Core.Memory.GenericExample
{
	/// <summary>
	/// Example behaviour. Its internal state can be restored by another behaviour. 
	/// </summary>
	public abstract class GameDataOwnerBase<T> : MonoBehaviour
	{
		/// <summary>
		/// Internal state.
		/// </summary>
		[SerializeField] private T _data;

		/// <summary>
		/// Get/Set internal state.
		/// </summary>
		public T Data
		{
			get { return _data; }
			set { _data = value; }
		}
	}
}
