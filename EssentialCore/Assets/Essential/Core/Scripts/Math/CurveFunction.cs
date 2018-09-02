using System;
using UnityEngine;

namespace _Scripts.Math
{
    [Serializable]
    public class CurveFunction : IFactor<float>, IFactor<double>
    {
        [SerializeField] private AnimationCurve _curve = AnimationCurve.Constant(0, 1, 1);

        public AnimationCurve Curve
        {
            get { return _curve; }
            set { _curve = value; }
        }

        public float Evaluate(float value, float time) // TODO move into other class
        {
            return value * Curve.Evaluate(time);
        }
        
        public double Evaluate(double value, float time) // TODO move into other class
        {
            return value * Curve.Evaluate(time);
        }
        
        public float Evaluate(float time)
        {
            return Curve.Evaluate(time);
        }
    }
}