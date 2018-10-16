using UnityEngine;

namespace Essential.Core.Memory.NonGenericExample
{
	/// <inheritdoc />
	/// <summary>
	/// Saves internal state from another script when user takes focus away from the Unity application to another
	/// application on his/her device + Restores the previous state from the other script, when the user switches
	/// bakc to the application.  
	/// </summary>
	[RequireComponent(typeof(GameDataOwner))]
	public class GameDataRecovery : MonoBehaviour
	{
		/// <summary>
		/// Used to save and restore the internal state of a behavioural script.
		/// </summary>
		private Originator<GameData> _originator;
		
		/// <summary>
		/// Used to save an internal state.
		/// </summary>
		private Caretaker<GameData> Caretaker { get; set; }
		
		/// <summary>
		/// Called when application is started.
		/// </summary>
		private void Start ()
		{
			var targetScript = GetComponent<GameDataOwner>();
			_originator	= new Originator<GameData>(targetScript);
		}
		
		/// <summary>
		/// Restore previous state from memento.
		/// </summary>
		// ReSharper disable once UnusedMember.Global
		public void RestorePreviousState()
		{
			_originator.RestoreFromMomento(Caretaker.Memento);
		}

		/// <summary>
		/// Save current state to memento.
		/// </summary>
		// ReSharper disable once UnusedMember.Global
		public void SaveCurrentState()
		{
			Caretaker = new Caretaker<GameData>(_originator.SaveToMemento());
		}
	}
}
