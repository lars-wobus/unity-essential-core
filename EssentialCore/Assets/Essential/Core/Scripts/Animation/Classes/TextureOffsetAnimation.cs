using Essential.Core.Animation.Data;
using UnityEngine;

namespace Essential.Core.Animation.Classes
{
	public class TextureOffsetAnimation : TextureOffsetAnimationBase {

		public TextureOffsetAnimation(MaterialData materialData) : base(materialData)
		{
		}
		
		/// <summary>
		/// Specifies which texture bound in shadder is affected by offset changes.
		/// </summary>
		[SerializeField] private string _shaderVariable = "_MainTex";
		
		public override void HandleProgressChange(float progress)
		{
			MaterialData.Material.SetTextureOffset(_shaderVariable, DefaultOffset + MaterialData.Alteration * progress);
		}
	}
}
