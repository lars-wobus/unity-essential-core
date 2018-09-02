using UnityEngine;
using System;

namespace _Scripts.Math
{
    [Serializable]
    public abstract class Range<T>
    {
        [SerializeField] private T _min;
        [SerializeField] private T _max;

        public T Min
        {
            get { return _min; }
            set { _min = value; }
        }

        public T Max
        {
            get { return _max; }
            set { _max = value; }
        }
        
        protected abstract T Distance { get; }

        public abstract T Clamp(T value);
    }
}