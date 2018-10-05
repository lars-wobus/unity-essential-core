using System;

namespace Essential.Core.Memory.GenericExample
{
	/// <summary>
	/// Serialized version of a GameDataOwner holding a single integer value.
	/// </summary>
	[Serializable]
	public class GenericGameDataOwner : GameDataOwnerBase<IntGameData>{};
}
