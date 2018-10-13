using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Essential.Core.Memory
{
	/// <inheritdoc />
	/// <summary>
	/// Saves and restores the internal state from another script.
	/// </summary>
	/// <remarks>
	/// Works well with MonoBehaviour.OnApplicationFocus(bool) or MonoBehaviour.OnApplicationPause(bool).
	/// </remarks>
	/// <typeparam name="TData">Type of data to be saved.</typeparam>
	public abstract class MultiStateRecoveryBase<TData> : MonoBehaviour
	{
		/// <summary>
		/// Used to save and restore the internal state of a behavioural script.
		/// </summary>
		private Originator<TData> Originator { get; set; }
		
		/// <summary>
		/// Used to save an internal state.
		/// </summary>
		private Caretaker<List<TData>> Caretaker { get; set; }
		
		/// <summary>
		/// Optional MonoBehaviour providing functions to inform listeners. 
		/// </summary>
		private IMonitoring Monitoring { get; set; }

		/// <summary>
		/// Return number of saved states.
		/// </summary>
		// ReSharper disable once MemberCanBePrivate.Global
		public int SavedStates => Caretaker?.Memento.Count ?? 0;
		
		/// <summary>
		/// Called when application is started.
		/// </summary>
		private void Start ()
		{
			var targetScript = GetComponent<IRecoverable<TData>>();
			Originator	= new Originator<TData>(targetScript);
			Caretaker = new Caretaker<List<TData>>(new List<TData>());
			Monitoring = GetComponent<IMonitoring>();
		}

		/// <summary>
		/// Check if index is valid.
		/// </summary>
		/// <param name="index">Used to identify a specific state within the collection of previously saved states.</param>
		/// <returns>True if index points to existing state.</returns>
		private bool HasState(int index)
		{
			return index >= 0 && index < SavedStates;
		}

		/// <summary>
		/// Restore previous state from memento.
		/// </summary>
		// ReSharper disable once UnusedMember.Global
		public void RestorePreviousState()
		{
			RestoreState(SavedStates - 1);
			//Debug.Break();
		}
		
		/// <summary>
		/// Save current state.
		/// </summary>
		// ReSharper disable once UnusedMember.Global
		public void SaveCurrentState()
		{
			Caretaker.Memento.Add(Originator.SaveToMemento());
			Monitoring?.OnStateSaved(SavedStates - 1);
		}

		/// <summary>
		/// Restore selected state.
		/// </summary>
		/// <param name="index">Specifies which saved state should be restored.</param>
		// ReSharper disable once MemberCanBePrivate.Global
		public void RestoreState(int index)
		{
			if (!HasState(index))
			{
				Monitoring?.OnRestorationFailed(index);
				return;
			}
			
			Originator.RestoreFromMomento(Caretaker.Memento[index]);
			Monitoring?.OnStateRestored(index);
		}

		/// <summary>
		/// Remove selected state.
		/// </summary>
		/// <param name="index">Specifies which saved state should be removed.</param>
		// ReSharper disable once UnusedMember.Global
		public void RemoveState(int index)
		{
			if (!HasState(index))
			{
				Monitoring.OnRemovingFailed(index);
				return;
			}
			
			Caretaker.Memento.RemoveAt(index);
			Monitoring?.OnStateRemoved(index);
		}

		/// <summary>
		/// Remove all saved states.
		/// </summary>
		// ReSharper disable once UnusedMember.Global
		public void ClearStates()
		{
			Caretaker.Memento.Clear();
		}
	}
}
