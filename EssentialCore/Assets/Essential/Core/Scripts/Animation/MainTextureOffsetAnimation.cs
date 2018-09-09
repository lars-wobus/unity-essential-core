﻿namespace Essential.Core.Animation
{
    public class MainTextureOffsetAnimation : TextureOffsetAnimationBase, IAnimationProgress
    {
        /*private void Update()
        {
            ChangeTextureOffset();
        }*/

        protected override void ChangeTextureOffset(float speed)
        {
            Material.mainTextureOffset += Alteration * speed;
        }

        public void SetProgress(float deltaTime)
        {
            ChangeTextureOffset(deltaTime);
        }
    }
}