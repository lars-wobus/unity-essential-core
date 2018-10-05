using UnityEngine;

namespace Essential.Core.Memory
{
	/// <summary>
	/// Saves internal state from another script when user takes focus away from the Unity application to another
	/// application on his/her device + Restores the previous state from the other script, when the user switches
	/// bakc to the application.  
	/// </summary>
	[RequireComponent(typeof(GameDataRestorer))]
	public class GameDataRecovery : MonoBehaviour
	{
		/// <summary>
		/// 
		/// </summary>
		private readonly Originator<GameDataRestorer.Data> _originator = new Originator<GameDataRestorer.Data>();
		
		/// <summary>
		/// The other script holding the 
		/// </summary>
		private GameDataRestorer TargetScript { get; set; }
		
		/// <summary>
		/// Used to save an internal state
		/// </summary>
		private Caretaker<GameDataRestorer.Data> Caretaker { get; set; }
		
		/// <summary>
		/// Called when application is started.
		/// </summary>
		private void Start ()
		{
			TargetScript = GetComponent<GameDataRestorer>();
			_originator.CurrentState = TargetScript.Data2;
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
				TargetScript.Data2 = _originator.RestoreFromMomento(Caretaker.Memento);
			}
			else
			{
				Caretaker = new Caretaker<GameDataRestorer.Data>(_originator.SaveToMemento());
			}
		}

		/*private void OnApplicationPause(bool pauseStatus)
		{
			throw new System.NotImplementedException();
		}*/
	}
}
