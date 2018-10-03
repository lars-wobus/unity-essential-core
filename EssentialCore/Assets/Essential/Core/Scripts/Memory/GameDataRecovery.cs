using UnityEngine;

namespace Essential.Core.Memory
{
	[RequireComponent(typeof(GameDataRestorer))]
	public class GameDataRecovery : MonoBehaviour
	{
		private GameDataRestorer _script;
		private Caretaker<GameDataRestorer.Data> _caretaker;
		private Originator<GameDataRestorer.Data> _originator = new Originator<GameDataRestorer.Data>();
		
		// Use this for initialization
		private void Start ()
		{
			_script = GetComponent<GameDataRestorer>();
			_originator.CurrentState = _script.Data2;
		}
	
		private void OnApplicationFocus(bool hasFocus)
		{
			Debug.Log("OnApplicationFocus " + hasFocus);
			Debug.Log(_originator.CurrentState.a);
			if (hasFocus)
			{
				//_data = _originator.CurrentState;
				_script.Data2 = _originator.RestoreFromMomento(_caretaker.Memento);
				Debug.Log("Use state from originator");
			}
			else
			{
				_caretaker = new Caretaker<GameDataRestorer.Data>(_originator.SaveToMemento());
				Debug.Log("Save state through" +
				          " originator");
			}
			Debug.Log(_originator.CurrentState.a);
		}

		/*private void OnApplicationPause(bool pauseStatus)
		{
			throw new System.NotImplementedException();
		}*/
	}
}
