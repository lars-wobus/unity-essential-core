using Essential.Core.Animation.Data;
using UnityEngine;

namespace Essential.Core.Animation.Classes
{
	/// <inheritdoc />
	/// <summary>
	/// TODO
	/// </summary>
	public class TextureScalingAnimator : TextureAnimator
	{
		private TextureData TextureData { get; }
		
		public TextureScalingAnimator(TextureData textureData)
		{
			TextureData = textureData;
			DefaultValue = textureData.Material.GetTextureScale(TextureData.ShaderVariable);
		}
        
		public override void HandleProgressChange(float progress)
		{
			TextureData.Material.SetTextureScale(TextureData.ShaderVariable, DefaultValue + TextureData.Alteration * progress);
		}
	}
}
