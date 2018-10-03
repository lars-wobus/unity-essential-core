using System;
using UnityEngine;

namespace Essential.Core.Memory
{
    public class GameDataRestorer : MonoBehaviour
    {
        [Serializable]
        public class Data
        {
            public int a;
        }

        private Data _data = new Data();
        private Caretaker<Data> _caretaker;
        private Originator<Data> _originator = new Originator<Data>();

        private void Start()
        {
            _originator.CurrentState = _data;
        }

        public void Update()
        {
            _data.a++;
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            Debug.Log("OnApplicationFocus " + hasFocus);
            Debug.Log(_data.a);
            if (hasFocus)
            {
                //_data = _originator.CurrentState;
                _data = _originator.RestoreFromMomento(_caretaker.Memento);
                Debug.Log("Use state from originator");
            }
            else
            {
                _caretaker = new Caretaker<Data>(_originator.SaveToMemento());
                Debug.Log("Save state through" +
                          " originator");
            }
            Debug.Log(_data.a);
        }

        /*
        private List<Originator<Data>> _originators = new List<Originator<A>>();
        
        
    
        public void RegisterData(A a)
        {
            _originators.Add(new Originator<A>());
        }
    
        public void SaveStates()
        {
            foreach (var originator in _originators)
            {
                originator.SaveToMemento();
            }
        }

        public void RestoreStates(A a)
        {
            foreach (var originator in _originators)
            {
                originator.RestoreFromMomento(a);
            }
        }*/
    }
}
