using UnityEngine;

namespace _Scripts.Math
{
	public class Filter : MonoBehaviour
	{
		[SerializeField] private AnimationCurve _curve = AnimationCurve.Constant(0, 1, 1);

		public AnimationCurve Curve
		{
			get { return _curve; }
			set
			{
				if (value == null) return; 
				_curve = value;
			}
		}
		
		public float Evaluate(float time)
		{
			return Curve.Evaluate(time);
		}
	}
}
