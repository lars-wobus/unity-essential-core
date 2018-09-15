using System;
using Essential.Core.Animation.Data;
using UnityEngine;

namespace Essential.Core.Animation.Classes
{
    /// <inheritdoc />
    /// <summary>
    /// Animate main texture offset of Material.
    /// </summary>
    public class MainTextureOffsetAnimation : TextureOffsetAnimationBase {

        public MainTextureOffsetAnimation(MaterialData materialData) : base(materialData)
        {
        }
        
        public override void HandleProgressChange(float progress)
        {
            Debug.Log(DefaultOffset + " " +MaterialData.Alteration + " " + progress);
            MaterialData.Material.mainTextureOffset = DefaultOffset + MaterialData.Alteration * progress;
            Debug.Log(MaterialData.Material.mainTextureOffset);
        }
    }
}
