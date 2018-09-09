using UnityEngine;

namespace Essential.Core.Animation
{
	public class TextureOffsetAnimation : TextureOffsetAnimationBase, ISync
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
		
		protected override void ChangeTextureOffset()
		{
			var textureOffset = Material.GetTextureOffset(ShaderVariable);
			Material.SetTextureOffset(ShaderVariable, textureOffset + Alteration);
		}

		public void HandleUpdate()
		{
			ChangeTextureOffset();
		}
	}
}