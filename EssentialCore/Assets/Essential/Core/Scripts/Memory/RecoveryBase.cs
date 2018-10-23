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
	public abstract class RecoveryBase<TData> : Caretaker<TData>
	{
		/// <summary>
		/// Optional MonoBehaviour providing functions to inform listeners. 
		/// </summary>
		private IStateMonitor StateMonitor { get; set; }

		/// <summary>
		/// Return number of saved states.
		/// </summary>
		// ReSharper disable once MemberCanBePrivate.Global
		public int SavedStates => Memento.Count;
		
		/// <summary>
		/// Called when application is started.
		/// </summary>
		private new void Start ()
		{
			base.Start();
			StateMonitor = GetComponent<IStateMonitor>();
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
			Memento.Add(Originator.SaveStateToMemento());
			StateMonitor?.OnStateSaved(SavedStates - 1);
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
				StateMonitor?.OnRestorationFailed(index);
				return;
			}
			
			Originator.RestoreStateFromMomento(Memento[index]);
			StateMonitor?.OnStateRestored(index);
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
				StateMonitor.OnRemovingFailed(index);
				return;
			}
			
			Memento.RemoveAt(index);
			StateMonitor?.OnStateRemoved(index);
		}

		/// <summary>
		/// Remove all saved states.
		/// </summary>
		// ReSharper disable once UnusedMember.Global
		public void ClearStates()
		{
			Memento.Clear();
			StateMonitor?.OnStatesCleared();
		}
	}
}
