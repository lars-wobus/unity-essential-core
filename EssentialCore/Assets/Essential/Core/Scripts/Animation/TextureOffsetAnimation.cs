using UnityEngine;

namespace Essential.Core.Animation
{
	public class TextureOffsetAnimation : TextureOffsetAnimationBase, IAnimationProgress
	{
		[SerializeField] private string _shaderVariable = "_MainTex";
		public string ShaderVariable
		{
			get { return _shaderVariable; }
			set { _shaderVariable = value; }
		}

		/*private void Update()
		{
			ChangeTextureOffset();
		}*/
		
		protected override void ChangeTextureOffset(float speed)
		{
			var textureOffset = Material.GetTextureOffset(ShaderVariable);
			Material.SetTextureOffset(ShaderVariable, textureOffset + Alteration * speed);
		}

		public void SetProgress(float deltaTime)
		{
			ChangeTextureOffset(deltaTime);
		}
	}
}