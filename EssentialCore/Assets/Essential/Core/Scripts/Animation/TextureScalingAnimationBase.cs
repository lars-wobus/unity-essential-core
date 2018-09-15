using UnityEngine;

namespace Essential.Core.Animation
{
	/// <inheritdoc />
	/// <summary>
	/// Base class for all animations changing the tiling of a textures. 
	/// </summary>
	public abstract class TextureScalingAnimationBase : TextureAnimationBase
	{
		/*/// <summary>
		/// Get or set texture scale.
		/// </summary>
		protected Vector2 DefaultScale { get; private set; }

		private void Start()
		{
			DefaultScale = Material.mainTextureScale;
		}

		protected override void OnApplicationQuit()
		{
			Material.mainTextureScale = DefaultScale;
		}*/
	}
}