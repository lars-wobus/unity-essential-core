using UnityEngine;

namespace Essential.Core.Animation.Classes
{
	public abstract class TextureOffsetAnimationBase : TextureAnimationBase
	{	
		/// <summary>
		/// Keep texture scale from start.
		/// </summary>
		protected Vector2 DefaultOffset { get; private set; }
		
		public override void HandleApplicationStart()
		{
			DefaultOffset = Material.mainTextureOffset;
		}

		public override void HandleApplicationQuit()
		{
			Material.mainTextureOffset = DefaultOffset;
		}
	}
}
