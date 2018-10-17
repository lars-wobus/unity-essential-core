using System;

namespace Essential.Core.Scripts.Memory.Examples
{
	[Flags]
	public enum ComplexEnum
	{
		None = 0,
		Poisoned = 1 << 0,
		Burning = 1 << 1,
		Frozen = 1 << 2,
		Electrified = 1 << 3,
		Sleepy = 1 << 4,
		Silent = 1 << 5,
		Cripple = 1 << 6
	}
}
