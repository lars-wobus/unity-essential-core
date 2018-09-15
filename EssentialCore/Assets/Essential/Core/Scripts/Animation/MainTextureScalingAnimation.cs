namespace Essential.Core.Animation
{
	/// <inheritdoc />
	/// <summary>
	/// Animate main texture tiling of Material.
	/// </summary>
	public class MainTextureScalingAnimation : TextureScalingAnimationBase
	{
		public override void SetProgress(double progress)
		{
			Material.mainTextureScale = DefaultScale + Alteration * (float) progress;
		}
	}
}