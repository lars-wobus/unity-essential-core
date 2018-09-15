using UnityEngine;

namespace Essential.Core.Animation
{
	/// <inheritdoc />
	/// <summary>
	/// Animate tiling of texture bound in shader. 
	/// </summary>
	public class TextureScalingAnimation : TextureScalingAnimationBase
	{
		/// <summary>
		/// Specifies which texture bound in shadder is affected by scale changes.
		/// </summary>
		[SerializeField] private string _shaderVariable = "_MainTex";

		public override void SetProgress(double progress)
		{
			Material.SetTextureScale(_shaderVariable, DefaultScale + Alteration * (float) progress);
		}
	}
}