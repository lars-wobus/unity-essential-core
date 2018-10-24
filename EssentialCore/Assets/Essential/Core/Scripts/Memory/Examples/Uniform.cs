using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Essential.Core.Scripts.Memory.Examples
{
    /// <summary>
    /// Uniform manipulation of transform components over time.
    /// </summary>
    public static class Uniform {
    
        /// <summary>
        /// Move object towards offset in seconds.
        /// </summary>
        /// <param name="transform">Transform of target object.</param>
        /// <param name="offset">Relative displacement of target object.</param>
        /// <param name="seconds">(Optional) Seconds to move to target position. Default is 1 second.</param>
        /// <param name="done">(Optional) Callback function to inform others about completion.</param>
        /// <returns></returns>
        public static IEnumerator MoveTowardsInSeconds(Transform transform, Vector3 offset, float seconds = 1.0f, UnityAction done = null)
        {
            var startPosition = transform.position;
            var endPosition = transform.position + offset;

            float step = Time.fixedDeltaTime / seconds;
            float time = 0.0f;
            while (time < 1.0f)
            {
                time += step;
                transform.position = Vector3.Lerp(startPosition, endPosition, time);
                yield return new WaitForFixedUpdate();
            }

            if(done != null)
            {
                done();
            }
        }

        /// <summary>
        /// Rotate around Y axis in seconds.
        /// </summary>
        /// <param name="transform">Transform of target object.</param>
        /// <param name="angle">The target object will be rotated right on positive values, and left on negative values.</param>
        /// <param name="seconds">(Optional) Seconds to move to target position. Default is 1 second.</param>
        /// <param name="done">(Optional) Callback function to inform others about completion.</param>
        /// <returns></returns>
        public static IEnumerator RotateAroundYInSeconds(Transform transform, float angle, float seconds = 1.0f, UnityAction done = null)
        {
            var from = transform.rotation;
            var to = Quaternion.Euler(transform.eulerAngles + transform.up * angle);

            float step = Time.fixedDeltaTime / seconds;
            float time = 0.0f;
            while (time < 1.0f)
            {
                time += step;
                transform.rotation = Quaternion.Slerp(from, to, time);
                yield return new WaitForFixedUpdate();
            }

            if (done != null)
            {
                done();
            }
        }
    }
}
