using Essential.Core.Debugging;
using UnityEngine;

namespace Essential.Core.Animation
{
	/// <inheritdoc />
	/// <summary>
	/// Base class for all animations operating on textures.
	/// </summary>
	public abstract class TextureAnimationBase : AnimationBase
	{
		/*/// <summary>
		/// Store for the Material property.
		/// </summary>
		[SerializeField] private Material _material;
		
		/// <summary>
		/// Store for the Alteration property.
		/// </summary>
		[SerializeField] private Vector2 _alteration;

		/// <summary>
		/// Get or set the affected Material.
		/// </summary>
		public Material Material
		{
			get { return _material; }
			set { _material = value; }
		}

		/// <summary>
		/// Get or set the Alteration who is applied to the affected Material.
		/// </summary>
		public Vector2 Alteration
		{
			get { return _alteration; }
			set { _alteration = value; }
		}

		/// <summary>
		/// Check if affected material was set up properly.
		/// </summary>
		private void Start()
		{
			SafeGuard.ThrowNullReferenceExceptionWhenComponentIsNull(Material, this, nameof(Material));
		}

		/// <summary>
		/// Revert changes on application end, otherwise version control will mark Material as modified.
		/// </summary>
		protected abstract void OnApplicationQuit();*/
	}
}