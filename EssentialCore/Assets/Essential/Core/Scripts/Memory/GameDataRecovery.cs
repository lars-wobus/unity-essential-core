using UnityEngine;

namespace Essential.Core.Memory
{
	// Note: Why not implementing methods from Orginator here? Because of the 'single responsible principle'. 
	// Moreover multiple versions of the originator might be required someday.
	// So why not inherting from an abstract version of Originator with type parameter which inherits from MonoBehaviour?
	// Because something like this: 'public class MementoBehaviour<TBehaviour, TData> : MonoBehaviour' would force us
	// to implement another interface for TBehaviour, to have access to the Data object.
	// Another possible solution could be 'public class MementoBehaviour<TBehaviour<TData>>'. Right now I didn't 
	// spend enought time to evaluate this strategy.
	
	[RequireComponent(typeof(GameDataRestorer))]
	public class GameDataRecovery : MonoBehaviour
	{
		private readonly Originator<GameDataRestorer.Data> _originator = new Originator<GameDataRestorer.Data>();
		private GameDataRestorer TargetScript { get; set; }
		private Caretaker<GameDataRestorer.Data> Caretaker { get; set; }
		
		// Use this for initialization
		private void Start ()
		{
			TargetScript = GetComponent<GameDataRestorer>();
			_originator.CurrentState = TargetScript.Data2;
		}
	
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
