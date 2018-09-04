using System;

namespace Essential.Core.Converter
{
	public static class ByteArray {
		public static byte[] BlockCopy<T>(T[] array, int size)
		{
			var byteArray = new byte[array.Length * size];
			Buffer.BlockCopy(array, 0, byteArray, 0, byteArray.Length);
			return byteArray;
		}
	
		public static byte[] FromSimpleTypeArray(bool[] array)
		{
			return BlockCopy(array, sizeof(bool));
		}
	
		public static byte[] FromSimpleTypeArray(char[] array)
		{
			return BlockCopy(array, sizeof(char));
		}
	
		public static byte[] FromSimpleTypeArray(decimal[] array)
		{
			return BlockCopy(array, sizeof(decimal));
		}
	
		public static byte[] FromSimpleTypeArray(double[] array)
		{
			return BlockCopy(array, sizeof(double));
		}
	
		public static byte[] FromSimpleTypeArray(float[] array)
		{
			return BlockCopy(array, sizeof(float));
		}
	
		public static byte[] FromSimpleTypeArray(int[] array)
		{
			return BlockCopy(array, sizeof(int));
		}
	
		public static byte[] FromSimpleTypeArray(uint[] array)
		{
			return BlockCopy(array, sizeof(uint));
		}
	
		public static byte[] FromSimpleTypeArray(long[] array)
		{
			return BlockCopy(array, sizeof(long));
		}
	
		public static byte[] FromSimpleTypeArray(ulong[] array)
		{
			return BlockCopy(array, sizeof(ulong));
		}
	
		public static byte[] FromSimpleTypeArray(short[] array)
		{
			return BlockCopy(array, sizeof(short));
		}
	
		public static byte[] FromSimpleTypeArray(ushort[] array)
		{
			return BlockCopy(array, sizeof(ushort));
		}

	}
}
