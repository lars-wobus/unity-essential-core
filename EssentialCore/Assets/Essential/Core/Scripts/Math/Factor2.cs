using System;
using UnityEngine;

namespace _Scripts.Math
{
    [Serializable]
    public class Factor2 : IFactor<Vector2>
    {
        [SerializeField] private AnimationCurve _x = AnimationCurve.Constant(0, 1, 1);
        [SerializeField] private AnimationCurve _y = AnimationCurve.Constant(0, 1, 1);

        private AnimationCurve X
        {
            get { return _x; }
            set { _x = value; }
        }

        private AnimationCurve Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public Vector2 Evaluate(Vector2 vector, float time)
        {
            return new Vector2(
                vector.x * X.Evaluate(time),
                vector.y * Y.Evaluate(time));
        }
    }
}