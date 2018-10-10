using UnityEngine;

namespace Essential.Core.Memory
{
	/// <inheritdoc />
	/// <summary>
	/// Example behaviour. Its internal state can be restored by another behaviour. 
	/// </summary>
	/// <typeparam name="TData">Type of data to own.</typeparam>
	public abstract class DataOwnerBase<TData> : MonoBehaviour, IRecoverable<TData>
	{
		/// <summary>
		/// Internal state.
		/// </summary>
		[SerializeField] private TData _data;

		/// <summary>
		/// Get/Set internal state.
		/// </summary>
		public TData Data
		{
			get { return _data; }
			set { _data = value; }
		}
	}
}
