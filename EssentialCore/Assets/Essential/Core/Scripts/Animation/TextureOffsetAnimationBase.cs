using Essential.Core.Debugging;
using UnityEngine;

namespace Essential.Core.Animation
{
	public abstract class TextureOffsetAnimationBase : MonoBehaviour
	{
		[SerializeField] private Material _material;
		[SerializeField] private Vector2 _alteration;

		public Material Material
		{
			get { return _material; }
			set { _material = value; }
		}

		public Vector2 Alteration
		{
			get { return _alteration; }
			set { _alteration = value; }
		}

		private void Start()
		{
			SafeGuard.ThrowNullReferenceExceptionWhenComponentIsNull(Material, this, nameof(Material));
		}

		protected abstract void ChangeTextureOffset();

		private void OnApplicationQuit()
		{
			Material.mainTextureOffset = Vector2.zero;
		}
	}
}