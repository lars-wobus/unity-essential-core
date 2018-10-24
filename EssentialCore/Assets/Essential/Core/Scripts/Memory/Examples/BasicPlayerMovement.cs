using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Essential.Core.Scripts.Memory.Examples
{
    public class BasicPlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _seconds = 10.0f;
        [SerializeField] private float _stepSize = 1.2f;
        [SerializeField] private UnityEvent _postureChanged;

        private float Seconds {
            get
            {
                return _seconds;
            }
            set
            {
                if (value < 0.0f)
                {
                    _seconds = 0.0f;
                }
            }
        }

        private float StepSize
        {
            get
            {
                return _stepSize;
            }
            set
            {
                if (value < 0.0f)
                {
                    _stepSize = 0.0f;
                }
            }
        }

        private IEnumerator Coroutine { get; set; }

#if UNITY_EDITOR
        private void Update()
        {
            Debug.DrawLine(transform.position, transform.position + transform.forward, Color.red);
        }
#endif

        private void Move(Vector3 offset)
        {
            if (Coroutine == null)
            {
                Coroutine = Uniform.MoveTowardsInSeconds(transform, offset, Seconds, ReleaseCoroutine);
                StartCoroutine(Coroutine);
            }
        }

        public void Forward()
        {
            Move(transform.forward * StepSize);
        }

        public void Backward()
        {
            Move(-transform.forward * StepSize);
        }

        public void Left()
        {
            Move(-transform.right * StepSize);
        }

        public void Right()
        {
            Move(transform.right * StepSize);
        }

        private void Rotate(float degrees)
        {
            if (Coroutine == null)
            {
                Coroutine = Uniform.RotateAroundYInSeconds(transform, degrees, Seconds, ReleaseCoroutine);
                StartCoroutine(Coroutine);
            }
        }

        public void RotateLeft()
        {
            Rotate(-90);
        }

        public void RotateRight()
        {
            Rotate(90);
        }

        private void ReleaseCoroutine()
        {
            _postureChanged.Invoke();
            Coroutine = null;
        }
    }

}
