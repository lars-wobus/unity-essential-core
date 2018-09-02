using UnityEngine;

// Obsolete: Use Mathf/Vector2/Vector3 with .lerp , inverselerp, + rescaling with distance between new max - min

namespace _Scripts.Math
{
	public class MathX
	{
		// Methods for normalization
		
		public static float Normalize(float value, float minValue, float maxValue)
		{
			return (value - minValue) / (maxValue - minValue);
		}
	
		public static double Normalize(double value, double minValue, double maxValue)
		{
			return (value - minValue) / (maxValue - minValue);
		}

		public static Vector2 Normalize(Vector2 value, Vector2 minValue, Vector2 maxValue)
		{
			return new Vector2(
				Normalize(value.x, minValue.x, maxValue.x),
				Normalize(value.y, minValue.y, maxValue.y)
			);
		}
		
		public static Vector3 Normalize(Vector3 value, Vector3 minValue, Vector3 maxValue)
		{
			return new Vector3(
				Normalize(value.x, minValue.x, maxValue.x),
				Normalize(value.y, minValue.y, maxValue.y),
				Normalize(value.z, minValue.z, maxValue.z)
			);
		}
		
		// Methods for rescaling
		
		public static float Rescale(float value, float minValue, float maxValue, float newMinValue, float newMaxValue)
		{
			return (newMaxValue - newMinValue) * (value - minValue) / (maxValue - minValue) + newMinValue;
		}
		
		public static double Rescale(double value, double minValue, double maxValue, double newMinValue, double newMaxValue)
		{
			return (newMaxValue - newMinValue) * (value - minValue) / (maxValue - minValue) + newMinValue;
		}
		
		public static Vector2 Rescale(Vector2 value, Vector2 minValue, Vector2 maxValue, Vector2 newMinValue, Vector2 newMaxValue)
		{
			return new Vector2(
				Rescale(value.x, minValue.x, maxValue.x, newMinValue.x, newMaxValue.x),
				Rescale(value.y, minValue.y, maxValue.y, newMinValue.y, newMaxValue.y)
			);
		}
		
		public static Vector3 Rescale(Vector3 value, Vector3 minValue, Vector3 maxValue, Vector3 newMinValue, Vector3 newMaxValue)
		{
			return new Vector3(
				Rescale(value.x, minValue.x, maxValue.x, newMinValue.x, newMaxValue.x),
				Rescale(value.y, minValue.y, maxValue.y, newMinValue.y, newMaxValue.y),
				Rescale(value.z, minValue.z, maxValue.z, newMinValue.z, newMaxValue.z)
			);
		}
	}
}
