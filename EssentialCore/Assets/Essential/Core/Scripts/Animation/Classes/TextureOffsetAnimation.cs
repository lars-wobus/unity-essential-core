using UnityEngine;

namespace Essential.Core.Animation.Classes
{
	public class TextureOffsetAnimation : TextureOffsetAnimationBase {

		/// <summary>
		/// Specifies which texture bound in shadder is affected by offset changes.
		/// </summary>
		[SerializeField] private string _shaderVariable = "_MainTex";
		
		public override void HandleProgressChange(float progress)
		{
			Material.SetTextureOffset(_shaderVariable, DefaultOffset + Alteration * progress);
		}
	}
}
