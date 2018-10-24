using Essential.Core.Memory;
using UnityEngine;

namespace Essential.Core.Scripts.Memory.Examples
{
	public class PostureImitation : MonoBehaviour, IRecoverable<TransformData>
	{
		[SerializeField] private Transform _target;
		[SerializeField] private TransformData _posture;
		
		public TransformData Data
		{
			get { return _posture;}
			set { _posture = value; }
		}

		public void UpdatePosture()
		{
			_posture.UpdatePosture(_target);
		}

		public void UpdateTransform()
		{
			_posture.SetPosture(_target);
		}
	}
}
