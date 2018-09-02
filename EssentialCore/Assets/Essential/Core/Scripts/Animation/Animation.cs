﻿using UnityEngine;

namespace Rapid.Animation
{
    public class Animation : IAnimation
    {
        [SerializeField] private int _counter;

        public int Counter
        {
            get { return _counter; }
            set { _counter = value; }
        }

        public void Start()
        {
            throw new System.NotImplementedException();
        }

        public void Stop()
        {
            Counter = 0;
            throw new System.NotImplementedException();
        }

        public void Continue()
        {
            throw new System.NotImplementedException();
        }

        public void Pause()
        {
            throw new System.NotImplementedException();
        }
    }
}