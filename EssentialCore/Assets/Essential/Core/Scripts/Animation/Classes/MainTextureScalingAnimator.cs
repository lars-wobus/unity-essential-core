using Essential.Core.Animation.Data;
using UnityEngine;

namespace Essential.Core.Animation.Classes
{
	/// <inheritdoc />
	/// <summary>
	/// TODO
	/// </summary>
	public class MainTextureScalingAnimator : TextureAnimatorBase {
        
		private MainTextureData MainTextureData { get; }

		public MainTextureScalingAnimator(MainTextureData mainTextureData)
		{
			MainTextureData = mainTextureData;
			DefaultValue = mainTextureData.Material.mainTextureScale;
		}
        
		public override void HandleProgressChange(float progress)
		{
			MainTextureData.Material.mainTextureScale = DefaultValue + MainTextureData.Alteration * progress;
		}
	}
}
