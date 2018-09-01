using Essential.Core.Extensions;
using Essential.Core.Tests.Configuration;
using NUnit.Framework;

namespace Essential.Core.Tests.Extensions
{
	public class FloatExtensionTest
	{

		[Test]
		public void Should_ReturnInputValue_When_RangeRemainsUnchanged()
		{
			const float value = 0.5f;

			var result = value.Remap(0, 1, 0, 1);

			Assert.AreEqual(value, result, TestSettings.DoublePrecision);
		}

		[Test]
		public void Should_ReturnInputValue_When_RangeLimitsWereReversed()
		{
			const float value = 0.5f;

			var result = value.Remap(0, 1, 1, 0);

			Assert.AreEqual(value, result, TestSettings.DoublePrecision);
		}

		[Test]
		public void Should_ReturnTwiceOfInputValue_When_EndOfNewRangeWasDoubled()
		{
			const float value = 0.5f;

			var result = value.Remap(0, 1, 0, 2);

			Assert.AreEqual(2 * value, result, TestSettings.DoublePrecision);
		}

		[Test]
		public void Should_ReturnNegativeOfInputValue_When_RangeLimitsWereNegated()
		{
			const float value = 0.5f;

			var result = value.Remap(0, 1, 0, -1);

			Assert.AreEqual(-value, result, TestSettings.DoublePrecision);
		}

		[Test]
		public void Should_ReturnNegativeOfInputValue_When_RangeLimitsWereNegatedAndReversed()
		{
			const float value = 0.5f;

			var result = value.Remap(0, 1, -1, 0);

			Assert.AreEqual(-value, result, TestSettings.DoublePrecision);
		}

		[Test]
		public void Should_ReturnNewRangeMinimum_When_NewRangeMinimumEqualsNewRangeMaximum()
		{
			const float value = 0.5f;

			var result = value.Remap(0, 1, 10, 10);

			Assert.AreEqual(10, result, TestSettings.DoublePrecision);
		}

		[Test]
		public void Should_ReturnNewRangeMinimum_When_InputValueWasSetToOldRangeMinimum()
		{
			const float value = 0f;

			var result = value.Remap(0, 1, -10, 10);

			Assert.AreEqual(-10, result, TestSettings.DoublePrecision);
		}

		[Test]
		public void Should_ReturnNewRangeMaximum_When_InputValueWasSetToOldRangeMaximum()
		{
			const float value = 1f;

			var result = value.Remap(0, 1, -10, 10);

			Assert.AreEqual(10, result, TestSettings.DoublePrecision);
		}

		[Test]
		public void Should_ReturnNewRangeMinimum_When_InputValueWasSmallerThanOldRangeMinimum()
		{
			const float value = -1f;

			var result = value.Remap(0, 1, 10, 100);

			Assert.AreEqual(10, result, TestSettings.DoublePrecision);
		}

		[Test]
		public void Should_ReturnNewRangeMaximum_When_InputValueWasGreaterThanOldRangeMaximum()
		{
			const float value = 10f;

			var result = value.Remap(0, 1, 10, 100);

			Assert.AreEqual(100, result, TestSettings.DoublePrecision);
		}

		[Test]
		public void Should_ReturnReliableResult_When_InputValueWasZero()
		{
			const float value = 0f;

			var result = value.Remap(-1, 1, 0, 100);

			Assert.AreEqual(100 / 2f, result, TestSettings.DoublePrecision);
		}

		[Test]
		public void Should_ReturnNaN_When_InputValueWasNaN()
		{
			const float value = float.NaN;

			var result = value.Remap(0, 1, 0, 1);

			Assert.AreEqual(float.NaN, result, TestSettings.DoublePrecision);
		}
		
		[Test]
		public void Should_ReturnNewRangeMinium_When_InputValueWasNaNAndOldRangeHasLengthOfZero()
		{
			const float value = float.NaN;

			var result = value.Remap(0, 0, -10, 10);

			Assert.AreEqual(-10, result, TestSettings.DoublePrecision);
		}

		[Test]
		public void Should_ReturnNaN_When_OldRangeContainsNaN()
		{
			const float value = 0.5f;

			var result = value.Remap(0, float.NaN, 0, 1);

			Assert.AreEqual(float.NaN, result, TestSettings.DoublePrecision);
		}

		[Test]
		public void Should_ReturnNaN_When_NewRangeContainsNaN()
		{
			const float value = 0.5f;

			var result = value.Remap(0, 1, 0, float.NaN);

			Assert.AreEqual(float.NaN, result, TestSettings.DoublePrecision);
		}

		[Test]
		public void Should_ReturnNewRangeMinium_When_OldRangeHasLengthOfZero()
		{
			const float value = 0.5f;

			var actual = value.Remap(0, 0, -10, 10);
			
			Assert.AreEqual(-10, actual, TestSettings.DoublePrecision);
		}
		
		[Test]
		public void Should_ReturnReliableResult_When_NewRangeHasLengthOfZero()
		{
			const float value = 0.5f;

			var actual = value.Remap(0, 1, 0, 0);
			
			Assert.AreEqual(0, actual, TestSettings.DoublePrecision);
		}
	}

}