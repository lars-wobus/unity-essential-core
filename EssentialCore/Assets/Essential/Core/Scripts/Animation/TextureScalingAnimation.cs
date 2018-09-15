using Essential.Core.Animation.Data;
using UnityEngine;

namespace Essential.Core.Animation
{
	/// <inheritdoc />
	/// <summary>
	/// Animate tiling of texture bound in shader. 
	/// </summary>
	public class TextureScalingAnimation : AnimationBase
	{
		[SerializeField] private TextureData _textureData;
        
		protected override void Start()
		{
			Animator = new Classes.TextureScalingAnimator(_textureData);
		}
	}
}