using UnityEngine;

namespace Essential.Core.Animation
{
	/// <inheritdoc />
	/// <summary>
	/// Base class for all animations changing the offset of a textures.
	/// </summary>
	public abstract class TextureOffsetAnimationBase : TextureAnimationBase
	{
		/*/// <summary>
		/// Keep texture scale from start.
		/// </summary>
		protected Vector2 DefaultOffset { get; private set; }

		private void Start()
		{
			DefaultOffset = Material.mainTextureOffset;
		}
		
		protected override void OnApplicationQuit()
		{
			Material.mainTextureOffset = DefaultOffset;
		}*/
	}
}