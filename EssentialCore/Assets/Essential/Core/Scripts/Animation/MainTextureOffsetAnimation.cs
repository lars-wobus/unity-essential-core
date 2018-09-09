namespace Essential.Core.Animation
{
    public class MainTextureOffsetAnimation : TextureOffsetAnimationBase, ISync
    {
        /*private void Update()
        {
            ChangeTextureOffset();
        }*/

        protected override void ChangeTextureOffset()
        {
            Material.mainTextureOffset += Alteration;
        }

        public void HandleUpdate()
        {
            ChangeTextureOffset();
        }
    }
}