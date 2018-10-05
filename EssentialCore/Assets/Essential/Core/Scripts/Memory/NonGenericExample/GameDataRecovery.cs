using UnityEngine;

namespace Essential.Core.Memory.NonGenericExample
{
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
		private readonly Originator<GameDataOwner.GameData> _originator = new Originator<GameDataOwner.GameData>();
		
		/// <summary>
		/// Reference to the behavioural script which shall be monitored.
		/// </summary>
		private GameDataOwner TargetScript { get; set; }
		
		/// <summary>
		/// Used to save an internal state.
		/// </summary>
		private Caretaker<GameDataOwner.GameData> Caretaker { get; set; }
		
		/// <summary>
		/// Called when application is started.
		/// </summary>
		private void Start ()
		{
			TargetScript = GetComponent<GameDataOwner>();
			_originator.CurrentState = TargetScript.Data;
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
				TargetScript.Data = _originator.RestoreFromMomento(Caretaker.Memento);
			}
			else
			{
				Caretaker = new Caretaker<GameDataOwner.GameData>(_originator.SaveToMemento());
			}
		}

		/*private void OnApplicationPause(bool pauseStatus)
		{
			throw new System.NotImplementedException();
		}*/
	}
}
