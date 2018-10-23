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
		private List<TData> SavedStates { get; set; }

		/// <summary>
		/// Used to save and restore the internal state of a behavioural script.
		/// </summary>
		private Originator<TData> Originator { get; set; }
		
		/// <summary>
		/// Return number of saved states.
		/// </summary>
		// ReSharper disable once MemberCanBeProtected.Global
		public int Count => SavedStates.Count;
		
		/// <summary>
		/// Called when application is started.
		/// </summary>
		protected void Start()
		{
			var targetScript = GetComponent<IRecoverable<TData>>();
			Originator = new Originator<TData>(targetScript);
			SavedStates = new List<TData>();
		}
		
		/// <summary>
		/// Check if index is valid.
		/// </summary>
		/// <param name="index">Used to identify a specific state within the collection of previously saved states.</param>
		/// <returns>True if index points to existing state.</returns>
		// ReSharper disable once MemberCanBePrivate.Global
		public bool HasState(int index)
		{
			return index >= 0 && index < Count;
		}

		/// <summary>
		/// Save current state.
		/// </summary>
		protected void SaveCurrentState()
		{
			SavedStates.Add(Originator.SaveStateToMemento());
		}

		/// <summary>
		/// Restore selected state.
		/// </summary>
		/// <param name="index">Specifies which saved state should be restored.</param>
		protected bool RestoreState(int index)
		{
			if (!HasState(index))
			{
				return false;
			}
			
			Originator.RestoreStateFromMomento(SavedStates[index]);
			return true;
		}

		/// <summary>
		/// Remove selected state.
		/// </summary>
		/// <param name="index">Specifies which saved state should be removed.</param>
		protected bool RemoveState(int index)
		{
			if (!HasState(index))
			{
				return false;
			}
			
			SavedStates.RemoveAt(index);
			return true;
		}

		/// <summary>
		/// Remove all saved states.
		/// </summary>
		protected void ClearStates()
		{
			SavedStates.Clear();
		}
	}
}