using Essential.Core.Memory;
using UnityEngine;

namespace Essential.Core.Scripts.Memory.Experimental
{
	public abstract class GameDataRecoveryBase<TGameDataRestorer, TData> : MonoBehaviour where TGameDataRestorer : GameDataOwnerBase<TData> where TData : GameData<int>
	{
		private readonly Originator<TData> _originator = new Originator<TData>();
		private TGameDataRestorer TargetScript { get; set; }
		private Caretaker<TData> Caretaker { get; set; }
		
		// Use this for initialization
		private void Start ()
		{
			TargetScript = GetComponent<TGameDataRestorer>();
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
				Caretaker = new Caretaker<TData>(_originator.SaveToMemento());
			}
		}
	}
}
