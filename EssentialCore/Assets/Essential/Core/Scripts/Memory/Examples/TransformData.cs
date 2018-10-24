using System;
using UnityEngine;

namespace Essential.Core.Scripts.Memory.Examples
{
    [Serializable]
    public class TransformData
    {
        [SerializeField] private float x, y, z;
        [SerializeField] private float rx, ry, rz;
        [SerializeField] private float sx, sy, sz;
        
        /*[SerializeField] private Vector3 _position;
        [SerializeField] private Vector3 _eulerAngles;
        [SerializeField] private Vector3 _scale;*/

        // SerializationException: Type 'UnityEngine.Transform' in Assembly

        public void UpdatePosture(Transform transform)
        {
            /*_position = _target.position;
            _eulerAngles = _target.eulerAngles;
            _scale = _target.localScale;*/

            x = transform.position.x;
            y = transform.position.y;
            z = transform.position.z;
            rx = transform.localEulerAngles.x;
            ry = transform.localEulerAngles.y;
            rz = transform.localEulerAngles.z;
            sx = transform.localScale.x;
            sy = transform.localScale.y;
            sz = transform.localScale.z;
        }
        
        public void SetPosture(Transform transform)
        {
            var position = new Vector3(x,y,z);
            var rotation = Quaternion.Euler(rx, ry, rz);
            transform.SetPositionAndRotation(position, rotation);
            transform.localScale = new Vector3(sx, sy, sz);
        }
    }
}
