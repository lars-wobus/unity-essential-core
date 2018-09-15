﻿using UnityEngine;

namespace Essential.Core.Animation.Classes
{
	public abstract class TextureAnimationBase : IAnimation
	{
		/*/// <summary>
		/// Store for the Material property.
		/// </summary>
		[SerializeField] private Material _material;
		
		/// <summary>
		/// Store for the Alteration property.
		/// </summary>
		[SerializeField] private Vector2 _alteration;

		/// <summary>
		/// Get or set the affected Material.
		/// </summary>
		public Material Material
		{
			get { return _material; }
			set { _material = value; }
		}

		/// <summary>
		/// Get or set the Alteration who is applied to the affected Material.
		/// </summary>
		public Vector2 Alteration
		{
			get { return _alteration; }
			set { _alteration = value; }
		}*/
		
		public abstract void HandleApplicationStart();

		public abstract void HandleApplicationQuit();

		public abstract void HandleProgressChange(float progress);
	}
}
