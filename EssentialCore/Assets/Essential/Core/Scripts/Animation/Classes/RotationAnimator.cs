using Essential.Core.Animation.Data;
using UnityEngine;

namespace Essential.Core.Animation.Classes
{
	/// <inheritdoc />
	/// <summary>
	/// TODO
	/// </summary>
	public class RotationAnimator : IAnimator
	{
		private RotationData RotationData { get; }
		
		/// <summary>
		/// Get or set transform component of the affected gameobject.
		/// </summary>
		private Transform Transform { get; }

		public RotationAnimator(RotationData rotationData, Transform transform)
		{
			RotationData = rotationData;
			Transform = transform;
		}
        
		public void HandleProgressChange(float progress)
		{
			RotationData.LimitedTime.Value = progress;
			Transform.Rotate(RotationData.Factor3.Evaluate(RotationData.Angles, RotationData.LimitedTime.Value), RotationData.Space);
		}

		public void HandleApplicationQuit()
		{
			RotationData.LimitedTime.Value = 0;
		}
	}
}
