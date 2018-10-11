﻿using UnityEngine;

namespace Essential.Core.Memory
{
	/// <inheritdoc />
	/// <summary>
	/// Saves internal state from another script when user takes focus away from the Unity application to another
	/// application on his/her device + Restores the previous state from the other script, when the user switches
	/// bakc to the application.  
	/// </summary>
	/// <typeparam name="TComponent">Script with public accessto its internal data.</typeparam>
	/// <typeparam name="TData">Type of data to be saved.</typeparam>
	public abstract class DataRecoveryBase<TComponent, TData> : MonoBehaviour where TComponent : IRecoverable<TData>
	{
		/// <summary>
		/// Used to save and restore the internal state of a behavioural script.
		/// </summary>
		private Originator<TData> _originator;
		
		/// <summary>
		/// Reference to the behavioural script which shall be monitored.
		/// </summary>
		private TComponent TargetScript { get; set; }
		
		/// <summary>
		/// Used to save an internal state.
		/// </summary>
		private Caretaker<TData> Caretaker { get; set; }
		
		/// <summary>
		/// Called when application is started.
		/// </summary>
		private void Start ()
		{
			TargetScript = GetComponent<TComponent>();
			//_originator.CurrentState = TargetScript.Data;
			// ReSharper disable once HeapView.BoxingAllocation
			_originator	= new Originator<TData>(TargetScript);
		}

		/// <summary>
		/// Restore previous state from memento.
		/// </summary>
		private void RestorePreviousState()
		{
			//TargetScript.Data = _originator.RestoreFromMomento(Caretaker.Memento);
			_originator.RestoreFromMomento(Caretaker.Memento);
			//Debug.Break();
		}

		/// <summary>
		/// Save current state to memento.
		/// </summary>
		private void SaveCurrentState()
		{
			Caretaker = new Caretaker<TData>(_originator.SaveToMemento());
		}

		/// <summary>
		/// Called when user switches between applications.
		/// </summary>
		/// <param name="hasFocus">True when user's focus is on this application, otherwise false.</param>
		/// <remarks>
		/// On Android devices when pressing the home button while the on-screen keyboard is shown OnApplicationPause is
		/// called instead of OnApplicationFocus.
		/// </remarks>
		private void OnApplicationFocus(bool hasFocus)
		{
			if (hasFocus)
			{
				RestorePreviousState();
			}
			else
			{
				SaveCurrentState();
			}
		}
	}
}