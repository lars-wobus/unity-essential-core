using Essential.Core.Converter;
using UnityEngine;

namespace Essential.Core.Extensions
{
    /// <summary>
    /// Contains extension methods for float data type.
    /// </summary>
    public static class FloatExtension
    {
        /// <summary>
        /// Remap number from one range to another.
        /// </summary>
        /// <remarks>
        /// When any parameter is NaN, the result will also be NaN.
        /// </remarks>
        /// <param name="value">Value to be remapped</param>
        /// <param name="aMin">Old range minimum</param>
        /// <param name="aMax">Old range maximum</param>
        /// <param name="bMin">New range minimum</param>
        /// <param name="bMax">New range maximum</param>
        /// <returns>Value within new range or NaN on certain inputs</returns>
        public static float Remap(this float value, float aMin, float aMax, float bMin, float bMax)
        {
            return Mathf.Lerp(bMin, bMax, Mathf.InverseLerp(aMin, aMax, value));
        }

        public static byte[] Convert(this float[] array)
        {
            return ByteArray.BlockCopy(array, sizeof(float));
        }
    }
}