using Essential.Core.Memory;
using UnityEngine;

namespace Essential.Core.Scripts.Memory.Examples
{
	/// <inheritdoc />
	/// <summary>
	/// Saves internal state from another script when user takes focus away from the Unity application to another
	/// application on his/her device + Restores the previous state from the other script, when the user switches
	/// bakc to the application.  
	/// </summary>
	[RequireComponent(typeof(SimpleDataOwner))]
	public class SimpleDataRecovery : MonoBehaviour
	{
		/// <summary>
		/// Used to save and restore the internal state of a behavioural script.
		/// </summary>
		private Originator<SimpleData> _originator;
		
		/// <summary>
		/// Used to save an internal state.
		/// </summary>
		private Caretaker<SimpleData> Caretaker { get; set; }
		
		/// <summary>
		/// Called when application is started.
		/// </summary>
		private void Start ()
		{
			var targetScript = GetComponent<SimpleDataOwner>();
			_originator	= new Originator<SimpleData>(targetScript);
		}
		
		/// <summary>
		/// Restore previous state from memento.
		/// </summary>
		// ReSharper disable once UnusedMember.Global
		public void RestorePreviousState()
		{
			_originator.RestoreStateFromMomento(Caretaker.Memento);
		}

		/// <summary>
		/// Save current state to memento.
		/// </summary>
		// ReSharper disable once UnusedMember.Global
		public void SaveCurrentState()
		{
			Caretaker = new Caretaker<SimpleData>(_originator.SaveStateToMemento());
		}
	}
}
