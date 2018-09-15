namespace Essential.Core.Animation
{
    /// <inheritdoc />
    /// <summary>
    /// Animate main texture offset of Material.
    /// </summary>
    public class MainTextureOffsetAnimation : TextureAnimationBase
    {
        public override void SetProgress(double progress)
        {
            Material.mainTextureOffset = Alteration * (float) progress;
        }
    }
}