using UnityEngine;

namespace Essential.Core.Animation
{
	/// <inheritdoc />
	/// <summary>
	/// Animate tiling of texture bound in shader. 
	/// </summary>
	public class TextureScalingAnimation : TextureAnimationBase
	{
		/// <summary>
		/// Specifies which texture bound in shadder is affected by scale changes.
		/// </summary>
		[SerializeField] private string _shaderVariable = "_MainTex";
		
		/// <summary>
		/// Keep texture scale from start.
		/// </summary>
		private Vector2 _mainTextureDefaultScale;

		private void Start()
		{
			_mainTextureDefaultScale = Material.mainTextureScale;
		}

		public override void SetProgress(double progress)
		{
			Material.SetTextureScale(_shaderVariable, _mainTextureDefaultScale + Alteration * (float) progress);
		}
		
		/// <summary>
		/// Revert changes on application end, otherwise version control will mark Material as modified.
		/// </summary>
		private void OnApplicationQuit()
		{
			Material.mainTextureScale = _mainTextureDefaultScale;
		}
	}
}