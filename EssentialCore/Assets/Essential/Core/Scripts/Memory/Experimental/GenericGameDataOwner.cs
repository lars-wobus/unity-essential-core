using System;
using UnityEngine;

namespace Essential.Core.Scripts.Memory.Experimental
{
	/// <summary>
	/// Serialized version of a GameDataOwner holding a single integer value.
	/// </summary>
	[Serializable]
	public class GenericGameDataOwner : GameDataOwnerBase<IntGameData>{};
}
