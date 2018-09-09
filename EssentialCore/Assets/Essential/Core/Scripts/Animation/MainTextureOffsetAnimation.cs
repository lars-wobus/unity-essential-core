namespace Essential.Core.Animation
{
    public class MainTextureOffsetAnimation : TextureOffsetAnimationBase
    {
        private void Update()
        {
            ChangeTextureOffset();
        }

        protected override void ChangeTextureOffset()
        {
            Material.mainTextureOffset += Alteration;
        }
    }
}