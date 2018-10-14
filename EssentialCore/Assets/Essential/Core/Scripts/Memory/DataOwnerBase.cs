using System.Collections;
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
		protected const int SecondsToWait = 1;

		/// <summary>
		/// Internal state.
		/// </summary>
		[SerializeField] private TData _data;

		private Coroutine Coroutine { get; set; }

		/// <summary>
		/// Get/Set internal state.
		/// </summary>
		public TData Data
		{
			get { return _data; }
			set { _data = value; }
		}

		public void StartUpdatingValues()
		{
			if (Coroutine != null)
			{
				return;
			}
			
			Coroutine = StartCoroutine(UpdateValues());
		}

		public void StopUpdatingValues()
		{
			if (Coroutine == null)
			{
				return;
			}
			
			StopCoroutine(Coroutine);
			Coroutine = null;
		}

		protected abstract IEnumerator UpdateValues();
	}
}
