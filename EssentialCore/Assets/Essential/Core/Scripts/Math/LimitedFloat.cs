using UnityEngine;
using System;
using UnityEngine.Experimental.UIElements;

namespace _Scripts.Math
{
    /// <summary>
    /// Defines which Mathf function shall be used to keep value within range.
    /// </summary>
    public enum Limit
    {
        None,
        Clamp,
        Pingpong,
        Repeat
    }
    
    /// <summary>
    /// Restricted floating point value.
    /// </summary>
    /// <example>
    /// LimitedTime.Value += Time.deltaTime;
    /// </example>
    /// <remarks>
    /// Pingpong mode requires another unlimited value,<br />
    /// e.g. LimitedTime.Value = MyUnlimitedValue += Time.deltaTime;
    /// </remarks>
    [Serializable]
    public class LimitedFloat
    {
        [SerializeField] private float _value = 0;
        // ReSharper disable once HeapView.ObjectAllocation.Evident
        [SerializeField] private Rangef _range = new Rangef(){ Min = 0, Max = 1 };
        [SerializeField] private Limit _limit = Limit.Clamp;

        public float Value
        {
            get { return _value; }
            set { _value = Evaluate(value); }
        }

        public Rangef Range
        {
            get { return _range; }
            set { _range = value; }
        }
        
        public Limit Limit
        {
            get { return _limit; }
            set { _limit = value; }
        }

        private float Evaluate(float value)
        {
            switch (Limit)
            {
                case Limit.None:
                {
                    return value;
                }
                case Limit.Clamp:
                {
                    return Range.Clamp(value);
                }
                case Limit.Pingpong:
                {
                    return Range.PingPong(value);
                }
                case Limit.Repeat:
                {
                    return Range.Repeat(value);
                }
                default:
                    // ReSharper disable once HeapView.ObjectAllocation.Evident
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}