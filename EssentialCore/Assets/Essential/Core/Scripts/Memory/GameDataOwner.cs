using System;
using UnityEngine;

namespace Essential.Core.Memory
{
    public class GameDataOwner : MonoBehaviour
    {
        [Serializable]
        public class Data
        {
            public int a;
        }

        [SerializeField] private Data _data;

        public Data Data2
        {
            get { return _data; }
            set { _data = value; }
        }

        public void Update()
        {
            _data.a++;
        }
    }
}
