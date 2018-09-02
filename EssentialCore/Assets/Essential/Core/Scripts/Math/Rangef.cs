using UnityEngine;
using System;

namespace _Scripts.Math
{
    [Serializable]
    public class Rangef : Range<float>
    {
        protected override float Distance
        {
            get
            {
                return Max - Min;
            }
        }
        
        public override float Clamp(float value)
        {
            return Mathf.Clamp(value, Min, Max);
        }

        public float PingPong(float value)
        {
            return Mathf.PingPong(value, Distance) + Min;
        }

        public float Repeat(float value)
        {
            return Mathf.Repeat(value, Distance) + Min;
        }
    }
}