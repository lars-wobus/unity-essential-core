using System;
using Essential.Core.Memory;
using UnityEngine;

namespace Essential.Core.Scripts.Memory.Examples
{
	[Serializable]
	public class InnerClass
	{
		[SerializeField] private bool _state;

		public bool State
		{
			get { return _state; }
			set { _state = value; }
		}
	}
	
	[Serializable]
	public class InnerClassExampleData : IRecoverable<InnerClass>
	{
		// Note: Initialize inner class or tag it as [Serializable] to prevent NullReferenceException
		[SerializeField] private InnerClass _data;
		[SerializeField] private int _number;
		
		public InnerClass Data
		{
			get { return _data; }
			set { _data = value; }
		}

		public int Number
		{
			get { return _number; }
			set { _number = value; }
		}
	}
}
