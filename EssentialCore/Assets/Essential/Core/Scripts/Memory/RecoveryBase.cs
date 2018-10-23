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
		/// Called when application is started.
		/// </summary>
		private new void Start ()
		{
			base.Start();
			StateMonitor = GetComponent<IStateMonitor>();
		}

		/// <summary>
		/// Restore previous state from memento.
		/// </summary>
		// ReSharper disable once UnusedMember.Global
		public void RestorePreviousState()
		{
			RestoreState(Count - 1);
		}
		
		/// <summary>
		/// Save current state.
		/// </summary>
		// ReSharper disable once UnusedMember.Global
		public new void SaveCurrentState()
		{
			base.SaveCurrentState();
			StateMonitor?.OnStateSaved(Count - 1);
		}

		/// <summary>
		/// Restore selected state.
		/// </summary>
		/// <param name="index">Specifies which saved state should be restored.</param>
		// ReSharper disable once MemberCanBePrivate.Global
		public new void RestoreState(int index)
		{
			if (!base.RestoreState(index))
			{
				StateMonitor?.OnRestorationFailed(index);
				return;
			}

			StateMonitor?.OnStateRestored(index);
		}

		/// <summary>
		/// Remove selected state.
		/// </summary>
		/// <param name="index">Specifies which saved state should be removed.</param>
		// ReSharper disable once UnusedMember.Global
		public new void RemoveState(int index)
		{
			if (!base.RemoveState(index))
			{
				StateMonitor?.OnRemovingFailed(index);
				return;
			}

			StateMonitor?.OnStateRemoved(index);
		}

		/// <summary>
		/// Remove all saved states.
		/// </summary>
		// ReSharper disable once UnusedMember.Global
		public new void ClearStates()
		{
			base.ClearStates();
			StateMonitor?.OnStatesCleared();
		}
	}
}
