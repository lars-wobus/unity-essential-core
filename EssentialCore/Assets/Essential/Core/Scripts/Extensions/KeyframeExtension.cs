using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Essential.Core.Extensions
{
	public static class KeyframeExtension
	{
		public static Keyframe InvertTime(this Keyframe keyframe)
		{
			keyframe.time = -keyframe.time;
			keyframe.inTangent = -keyframe.inTangent;
			keyframe.outTangent = -keyframe.outTangent;
			return keyframe;
		}
		
		public static Keyframe InvertValue(this Keyframe keyframe)
		{
			keyframe.value = -keyframe.value;
			keyframe.inTangent = -keyframe.inTangent;
			keyframe.outTangent = -keyframe.outTangent;
			return keyframe;
		}

		public static Keyframe RemapTime(this Keyframe keyframe, float aMin, float aMax, float bMin, float bMax)
		{
			keyframe.time = keyframe.time.Remap(aMin, aMax, bMin, bMax);
			return keyframe;
		}
		
		public static Keyframe RemapValue(this Keyframe keyframe, float aMin, float aMax, float bMin, float bMax)
		{
			keyframe.value = keyframe.value.Remap(aMin, aMax, bMin, bMax);
			return keyframe;
		}
		
		public static Keyframe[] InvertTimes(this IEnumerable<Keyframe> keyframes)
		{
			return keyframes.Select(keyframe => keyframe.InvertTime()).ToArray();
		}
		
		public static Keyframe[] InvertValues(this IEnumerable<Keyframe> keyframes)
		{
			return keyframes.Select(keyframe => keyframe.InvertValue()).ToArray();
		}

		public static Keyframe[] RemapTimes(this Keyframe[] keyframes, float bMin, float bMax)
		{
			if (keyframes.Length == 0)
			{
				return keyframes;
			}
			
			float aMin = keyframes.First().time;
			float aMax = keyframes.Last().time;
			return keyframes.Select(keyframe => keyframe.RemapTime(aMin, aMax, bMin, bMax)).ToArray();
		}
		
		public static Keyframe[] RemapValues(this Keyframe[] keyframes, float bMin, float bMax)
		{
			if (keyframes.Length == 0)
			{
				return keyframes;
			}
			
			float aMin = keyframes.Min(keyframe => keyframe.value);
			float aMax = keyframes.Max(keyframe => keyframe.value);
			return keyframes.Select(keyframe => keyframe.RemapValue(aMin, aMax, bMin, bMax)).ToArray();
		}
		
		
		/*public static Keyframe[] InvertValues(this IEnumerable<Keyframe> keyframes)
		{
			return keyframes.Select((keyframe) => new Keyframe(keyframe.time, -keyframe.value, -keyframe.inTangent, -keyframe.outTangent)).ToArray();
		}
        
		public static Keyframe[] InvertKeys(this IEnumerable<Keyframe> keyframes)
		{
			return keyframes.Select((keyframe) => new Keyframe(-keyframe.time, keyframe.value, -keyframe.inTangent, -keyframe.outTangent)).ToArray();
		}

		public static Keyframe[] Remap(this Keyframe[] keyframes, float bMin, float bMax)
		{
			float aMin = keyframes.First().time;
			float aMax = keyframes.Last().time;
			return keyframes.Select((keyframe) => new Keyframe(keyframe.time.Remap(aMin, aMax, bMin, bMax), keyframe.value, -keyframe.inTangent, -keyframe.outTangent)).ToArray();
		}*/
	}
}