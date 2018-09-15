using UnityEngine;

namespace Essential.Core.Animation
{
	/// <inheritdoc />
	/// <summary>
	/// Animate offset of texture bound in shader. 
	/// </summary>
	public class TextureOffsetAnimation : TextureOffsetAnimationBase
	{
		/// <summary>
		/// Specifies which texture bound in shadder is affected by offset changes.
		/// </summary>
		[SerializeField] private string _shaderVariable = "_MainTex";
		
		public override void SetProgress(double progress)
		{
			Material.SetTextureOffset(_shaderVariable, DefaultOffset + Alteration * (float)progress);
		}
	}
}