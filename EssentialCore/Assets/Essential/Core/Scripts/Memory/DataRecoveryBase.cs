﻿using UnityEngine;

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
	public abstract class DataRecoveryBase<TData> : MonoBehaviour
	{
		/// <summary>
		/// Used to save and restore the internal state of a behavioural script.
		/// </summary>
		private Originator<TData> _originator;
		
		/// <summary>
		/// Used to save an internal state.
		/// </summary>
		private Caretaker<TData> Caretaker { get; set; }
		
		/// <summary>
		/// Called when application is started.
		/// </summary>
		private void Start ()
		{
			var targetScript = GetComponent<IRecoverable<TData>>();
			_originator	= new Originator<TData>(targetScript);
		}

		/// <summary>
		/// Restore previous state from memento.
		/// </summary>
		public void RestorePreviousState()
		{
			_originator.RestoreFromMomento(Caretaker.Memento);
			//Debug.Break();
		}

		/// <summary>
		/// Save current state to memento.
		/// </summary>
		public void SaveCurrentState()
		{
			Caretaker = new Caretaker<TData>(_originator.SaveToMemento());
		}
	}
}
