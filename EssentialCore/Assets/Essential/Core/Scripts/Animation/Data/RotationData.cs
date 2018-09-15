using UnityEngine;
using _Scripts.Math;

namespace Essential.Core.Animation.Data
{
	[CreateAssetMenu(fileName = "RotationData_", menuName = "Animation/RotationData", order = 1)]
	public class RotationData : ScriptableObject {
		/// <summary>
		/// Store for the Angles property.
		/// </summary>
		[SerializeField] private Vector3 _angles;
        
		/// <summary>
		/// Store for the Space property.
		/// </summary>
		[SerializeField] private Space _space;

		/// <summary>
		/// Store for the Factor3 property.
		/// </summary>
		[SerializeField] private Factor3 _factor3;
        
		/// <summary>
		/// Store for the LimitedTime property.
		/// </summary>
		[SerializeField] private LimitedFloat _limitedTime;

		/// <summary>
		/// Get or set rotation speed per axis in three dimensional space.
		/// </summary>
		public Vector3 Angles
		{
			get { return _angles; }
			set { _angles = value; }
		}

		/// <summary>
		/// Get or set coordinate space for rotation.
		/// </summary>
		public Space Space
		{
			get { return _space; }
			set { _space = value; }
		}
        
		/// <summary>
		/// Get or set weighting of rotation speed per axis in three dimensional space.
		/// </summary>
		public Factor3 Factor3
		{
			get { return _factor3; }
			set { _factor3 = value; }
		}
        
		/// <summary>
		/// Get or set limitation for animation progress.
		/// </summary>
		public LimitedFloat LimitedTime
		{
			get { return _limitedTime; }
			set { _limitedTime = value; }
		}
	}
}
