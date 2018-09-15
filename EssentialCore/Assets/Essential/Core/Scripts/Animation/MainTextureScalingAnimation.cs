using Essential.Core.Animation.Data;
using UnityEngine;

namespace Essential.Core.Animation
{
	/// <inheritdoc />
	/// <summary>
	/// Animate main texture tiling of Material.
	/// </summary>
	public class MainTextureScalingAnimation : AnimationBase
	{
		[SerializeField] private MainTextureData _mainTextureData;
        
		protected override void Start()
		{
			Animation = new Classes.MainTextureScalingAnimator(_mainTextureData);
		}
	}
}