namespace Essential.Core.Animation.Classes
{
    public class MainTextureOffsetAnimation : TextureOffsetAnimationBase {
        public override void HandleProgressChange(float progress)
        {
            Material.mainTextureOffset = DefaultOffset + Alteration * progress;
        }
    }
}
