using UnityEngine;

namespace Essential.Core.Animation
{
	public class TextureOffsetAnimation : TextureOffsetAnimationBase, IAnimation
	{
		[SerializeField] private string _shaderVariable = "_MainTex";
		
		private string ShaderVariable => _shaderVariable;

		protected override void ChangeTextureOffset(float progress)
		{
			//var textureOffset = Material.GetTextureOffset(ShaderVariable);
			//Material.SetTextureOffset(ShaderVariable, textureOffset + Alteration * speed);
			Material.SetTextureOffset(ShaderVariable, Alteration * progress);
		}

		public void SetProgress(float progress)
		{
			ChangeTextureOffset(progress);
		}
	}
}