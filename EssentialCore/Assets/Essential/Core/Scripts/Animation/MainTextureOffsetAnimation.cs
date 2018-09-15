using UnityEngine;

namespace Essential.Core.Animation
{
    /// <inheritdoc />
    /// <summary>
    /// Animator to change offset of main texture of a Material.
    /// </summary>
    public class MainTextureOffsetAnimation : AnimationBase
    {
        [SerializeField] private Data.MaterialData _materialData;
        private Classes.TextureOffsetAnimationBase _class;
        
        private void Start()
        {
            _class = new Classes.MainTextureOffsetAnimation(_materialData);
            //_class.HandleApplicationStart();
        }

        public override void SetProgress(double progress)
        {
            _class.HandleProgressChange((float)progress);
        }

        private void OnApplicationQuit()
        {
            _class.HandleApplicationQuit();
        }
    }
}