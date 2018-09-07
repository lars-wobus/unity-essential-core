using System;
using System.Collections.Generic;
using Essential.Core.Debugging;
using UnityEngine;

namespace Rapid.Animation
{
    public class MaterialAnimation : MonoBehaviour
    {
        [SerializeField] private Material _material;
        [SerializeField] private Vector2 _alteration;

        public Material Material
        {
            get { return _material; }
            set { _material = value; }
        }
        
        public Vector2 Alteration
        {
            get { return _alteration; }
            set { _alteration = value; }
        }

        private void Start()
        {
            SafeGuard.ThrowNullReferenceExceptionWhenComponentIsNull(Material, this, nameof(Material));
        }
        
        private void Update()
        {
            Material.mainTextureOffset += Alteration;
        }
    }
}