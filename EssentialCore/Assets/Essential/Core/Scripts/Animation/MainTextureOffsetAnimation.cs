namespace Essential.Core.Animation
{
    /// <inheritdoc />
    /// <summary>
    /// Animate main texture offset of Material.
    /// </summary>
    public class MainTextureOffsetAnimation : TextureOffsetAnimationBase
    {
        public override void SetProgress(double progress)
        {
            Material.mainTextureOffset = DefaultOffset + Alteration * (float) progress;
        }
    }
}