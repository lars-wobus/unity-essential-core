using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Essential.Core.Extensions;
using Essential.Core.Tests.Configuration;
using NUnit.Framework;

public class KeyframeExtensionTest
{
	private Keyframe DefaultKeyframe { get; set; }
	public Keyframe[] EmptyKeyframes { get; private set; }
	public Keyframe[] Keyframes { get; private set; }

	[SetUp]
	public void Setup()
	{
		DefaultKeyframe = new Keyframe();
		EmptyKeyframes = new Keyframe[0];
		Keyframes = new Keyframe[]{
			new Keyframe(0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f),
			new Keyframe(0.5f, 0.5f, 0.5f, 0.5f, 0.5f, 0.5f),
			new Keyframe(1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f)
		};
	}

	[Test]
	public void Should_ReturnZero_WhenTimeSetToZeroShallBeInverted()
	{
		const float expected = 0;
		
		var actual = DefaultKeyframe.InvertTime().time;

		Assert.AreEqual(expected, actual, TestSettings.DoublePrecision);
	}
	
	[Test]
	public void Should_ReturnMinusOne_WhenTimeSetToOneShallBeInverted()
	{
		const float expected = -1;
		var keyframe = DefaultKeyframe;
		keyframe.time = 1;
		
		var actual = keyframe.InvertTime().time;

		Assert.AreEqual(expected, actual, TestSettings.DoublePrecision);
	}
	
	[Test]
	public void Should_ReturnZero_WhenValueSetToZeroShallBeInverted()
	{
		const float expected = 0;
		
		var actual = DefaultKeyframe.InvertValue().value;

		Assert.AreEqual(expected, actual, TestSettings.DoublePrecision);
	}
	
	[Test]
	public void Should_ReturnMinusOne_WhenValueSetToOneShallBeInverted()
	{
		const float expected = -1;
		var keyframe = DefaultKeyframe;
		keyframe.value = 1;
		
		var actual = keyframe.InvertValue().value;

		Assert.AreEqual(expected, actual, TestSettings.DoublePrecision);
	}
	
	[Test]
	public void Should_ReturnOne_WhenTimeIsRemapedFromZeroToOne()
	{
		const float expected = 1;
		
		var actual = DefaultKeyframe.RemapTime(0f, 1f, 1f, 2f).time;

		Assert.AreEqual(expected, actual, TestSettings.DoublePrecision);
	}
	
	[Test]
	public void Should_ReturnOne_WhenValueIsRemapedFromZeroToOne()
	{
		const float expected = 1;
		
		var actual = DefaultKeyframe.RemapValue(0f, 1f, 1f, 2f).value;

		Assert.AreEqual(expected, actual, TestSettings.DoublePrecision);
	}
	
	[Test]
	public void InvertKeys_Should_ReturnEmptyArray_When_NoKeyframesProvided()
	{
		const int expected = 0;
		
		var actual = EmptyKeyframes.InvertTimes().Length;
		
		Assert.AreEqual(expected, actual, TestSettings.DoublePrecision);
	}
	
	[Test]
	public void InvertValues_Should_ReturnEmptyArray_When_NoKeyframesProvided()
	{
		const int expected = 0;
		
		var actual = EmptyKeyframes.InvertValues().Length;
		
		Assert.AreEqual(expected, actual, TestSettings.DoublePrecision);
	}
	
	[Test]
	public void RemapTimes_Should_ReturnEmptyArray_When_NoKeyframesProvided()
	{
		const int expected = 0;
		
		var actual = EmptyKeyframes.RemapTimes(0.0f, 10.0f).Length;
		
		Assert.AreEqual(expected, actual, TestSettings.DoublePrecision);
	}
	
	[Test]
	public void RemapValues_Should_ReturnEmptyArray_When_NoKeyframesProvided()
	{
		const int expected = 0;
		
		var actual = EmptyKeyframes.RemapValues(0.0f, 10.0f).Length;
		
		Assert.AreEqual(expected, actual, TestSettings.DoublePrecision);
	}
	
	/*[Test]
	public void Should_ReturnInputValue_When_RangeRemainsUnchanged()
	{
		var result = Keyframes.InvertValues();
	}
	
	[Test]
	public void Should_ReturnInputValue_When_RangeRemainsUnchanged2()
	{
		var result = Keyframes.InvertTimes();
	}
	
	[Test]
	public void Should_ReturnInputValue_When_RangeRemainsUnchanged3()
	{
		var result = Keyframes.RemapTimes(0.0f, 10.0f);
	}*/
}
