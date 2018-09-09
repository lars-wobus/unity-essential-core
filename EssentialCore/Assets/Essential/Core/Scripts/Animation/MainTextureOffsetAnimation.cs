namespace Essential.Core.Animation
{
    public class MainTextureOffsetAnimation : TextureOffsetAnimationBase, IAnimation
    {
        protected override void ChangeTextureOffset(float progress)
        {
            //Material.mainTextureOffset += Alteration * speed;
            Material.mainTextureOffset = Alteration * progress;
        }

        public void SetProgress(float progress)
        {
            ChangeTextureOffset(progress);
        }
    }
}