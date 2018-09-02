using UnityEngine;
using _Scripts.Math;

namespace Rapid.Animation
{
    public class ContinuousRotation : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private Vector3 _angles;
        [SerializeField] private Space _space;

        [SerializeField] private Factor3 _factor3;
        [SerializeField] private LimitedFloat _limitedTime;
        
        private float _overallTime;
        public Transform Target
        {
            get { return _target; }
            set { _target = value; }
        }

        public Vector3 Angles
        {
            get { return _angles; }
            set { _angles = value; }
        }

        public Space Space
        {
            get { return _space; }
            set { _space = value; }
        }
        
        public Factor3 Factor3
        {
            get { return _factor3; }
            set { _factor3 = value; }
        }
        
        public LimitedFloat LimitedTime
        {
            get { return _limitedTime; }
            set { _limitedTime = value; }
        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;
            LimitedTime.Value += deltaTime;
            //FiniteTime.Value = _overallTime += deltaTime;
            Target.transform.Rotate(Factor3.Evaluate(Angles, LimitedTime.Value), Space);
        }
    }
}