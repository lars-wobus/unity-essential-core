using UnityEngine;
using System;
using Essential.Core.Animation.Data;

namespace Essential.Core.Animation.Classes
{
	public abstract class TextureOffsetAnimationBase : TextureAnimationBase
	{
		/// <summary>
		/// Keep texture scale from start.
		/// </summary>
		protected MaterialData MaterialData { get; }

		/// <summary>
		/// Keep texture scale from start.
		/// </summary>
		protected Vector2 DefaultOffset { get; }

		protected TextureOffsetAnimationBase(MaterialData materialData)
		{
			MaterialData = materialData;
			DefaultOffset = MaterialData.Material.mainTextureOffset;
		}
		
		public override void HandleApplicationStart()
		{
			//DefaultOffset = MaterialData.Material.mainTextureOffset; // TODO
		}

		public override void HandleApplicationQuit()
		{
			MaterialData.Material.mainTextureOffset = DefaultOffset;
		}
	}
}
