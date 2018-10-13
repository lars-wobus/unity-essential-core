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
	public abstract class SingleStateRecoveryBase<TData> : MonoBehaviour
	{
		/// <summary>
		/// Used to save and restore the internal state of a behavioural script.
		/// </summary>
		private Originator<TData> Originator { get; set; }
		
		/// <summary>
		/// Used to save an internal state.
		/// </summary>
		private Caretaker<TData> Caretaker { get; set; }
		
		/// <summary>
		/// Optional MonoBehaviour providing functions to inform listeners. 
		/// </summary>
		private ISingleStateMonitoring SingleStateMonitoring { get; set; }
		
		/// <summary>
		/// Called when application is started.
		/// </summary>
		private void Start ()
		{
			var targetScript = GetComponent<IRecoverable<TData>>();
			Originator = new Originator<TData>(targetScript);
			SingleStateMonitoring = GetComponent<ISingleStateMonitoring>();
		}

		/// <summary>
		/// Restore previous state from memento.
		/// </summary>
		// ReSharper disable once UnusedMember.Global
		public void RestorePreviousState()
		{
			Originator.RestoreFromMomento(Caretaker.Memento);
			SingleStateMonitoring?.OnStateRestored();
			//Debug.Break();
		}

		/// <summary>
		/// Save current state to memento.
		/// </summary>
		// ReSharper disable once UnusedMember.Global
		public void SaveCurrentState()
		{
			Caretaker = new Caretaker<TData>(Originator.SaveToMemento());
			SingleStateMonitoring?.OnStateSaved();
		}
	}
}
