using UnityEngine;

namespace Essential.Core.Animation
{
	/// <inheritdoc />
	/// <summary>
	/// Animate main texture tiling of Material.
	/// </summary>
	public class MainTextureScalingAnimation : TextureAnimationBase
	{
		/// <summary>
		/// Keep texture scale from start.
		/// </summary>
		private Vector2 _mainTextureDefaultScale;

		private void Start()
		{
			_mainTextureDefaultScale = Material.mainTextureScale;
		}
		
		public override void SetProgress(double progress)
		{
			Material.mainTextureScale = _mainTextureDefaultScale + Alteration * (float) progress;
		}
		
		/// <summary>
		/// Revert changes on application end, otherwise version control will mark Material as modified.
		/// </summary>
		private void OnApplicationQuit()
		{
			Material.mainTextureScale = _mainTextureDefaultScale;
		}
	}
}