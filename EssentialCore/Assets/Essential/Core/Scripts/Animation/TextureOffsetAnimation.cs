using Essential.Core.Animation.Data;
using UnityEngine;

namespace Essential.Core.Animation
{
	/// <inheritdoc />
	/// <summary>
	/// Animator to change offset of main texture of a Material.
	/// </summary>
	public class TextureOffsetAnimation : AnimationBase
	{
		[SerializeField] private TextureData _textureData;
        
		protected override void Start()
		{
			Animation = new Classes.TextureOffsetAnimator(_textureData);
		}
	}
}