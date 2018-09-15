using Essential.Core.Animation.Data;
using UnityEngine;

namespace Essential.Core.Animation.Classes
{
	/// <inheritdoc />
	/// <summary>
	/// TODO
	/// </summary>
	public class TextureOffsetAnimator : TextureAnimator {
        
		private TextureData TextureData { get; }

		public TextureOffsetAnimator(TextureData textureData)
		{
			TextureData = textureData;
			DefaultValue = textureData.Material.GetTextureOffset(TextureData.ShaderVariable);
		}
        
		public override void HandleProgressChange(float progress)
		{
			TextureData.Material.SetTextureOffset(TextureData.ShaderVariable, DefaultValue + TextureData.Alteration * progress);
		}
	}
}
