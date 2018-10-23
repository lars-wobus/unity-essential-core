using System.Collections.Generic;
using UnityEngine;

namespace Essential.Core.Memory
{
	/// <inheritdoc />
	/// <summary>
	/// Allows to store a single internal state of an Originator.
	/// </summary>
	/// <typeparam name="TData">Type of data to be saved.</typeparam>
	public abstract class Caretaker<TData> : MonoBehaviour
	{
		/// <summary>
		/// Save/Restore internal state of an originator.
		/// </summary>
		protected List<TData> Memento { get; private set; }

		/// <summary>
		/// Used to save and restore the internal state of a behavioural script.
		/// </summary>
		protected Originator<TData> Originator { get; private set; }
		
		/// <summary>
		/// Called when application is started.
		/// </summary>
		protected void Start()
		{
			var targetScript = GetComponent<IRecoverable<TData>>();
			Originator = new Originator<TData>(targetScript);
			Memento = new List<TData>();
		}
	}
}