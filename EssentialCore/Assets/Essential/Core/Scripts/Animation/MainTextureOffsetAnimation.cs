using Essential.Core.Animation.Data;
using UnityEngine;

namespace Essential.Core.Animation
{
    /// <inheritdoc />
    /// <summary>
    /// Animator to change offset of main texture of a Material.
    /// </summary>
    public class MainTextureOffsetAnimation : AnimationBase
    {
        [SerializeField] private MainTextureData _mainTextureData;
        
        protected override void Start()
        {
            Animation = new Classes.MainTextureOffsetAnimator(_mainTextureData);
        }
    }
}