using Essential.Core.Animation.Data;
using UnityEngine;

namespace Essential.Core.Animation.Classes
{
    /// <inheritdoc />
    /// <summary>
    /// TODO
    /// </summary>
    public class MainTextureOffsetAnimator : TextureAnimator
    {
        private MainTextureData MainTextureData { get; }

        public MainTextureOffsetAnimator(MainTextureData mainTextureData)
        {
            MainTextureData = mainTextureData;
            DefaultValue = mainTextureData.Material.mainTextureOffset;
        }
        
        public override void HandleProgressChange(float progress)
        {
            MainTextureData.Material.mainTextureOffset = DefaultValue + MainTextureData.Alteration * progress;
        }
    }
}
