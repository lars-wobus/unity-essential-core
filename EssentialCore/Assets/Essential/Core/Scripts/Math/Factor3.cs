using System;
using UnityEngine;

namespace _Scripts.Math
{
    [Serializable]
    public class Factor3 : IFactor<Vector3>
    {
        [SerializeField] private AnimationCurve _x = AnimationCurve.Constant(0, 1, 1);
        [SerializeField] private AnimationCurve _y = AnimationCurve.Constant(0, 1, 1);
        [SerializeField] private AnimationCurve _z = AnimationCurve.Constant(0, 1, 1);

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

        private AnimationCurve Z
        {
            get { return _z; }
            set { _z = value; }
        }

        public Vector3 Evaluate(Vector3 vector, float time)
        {
            return new Vector3(
                vector.x * X.Evaluate(time),
                vector.y * Y.Evaluate(time),
                vector.z * Z.Evaluate(time));
        }
    }
}