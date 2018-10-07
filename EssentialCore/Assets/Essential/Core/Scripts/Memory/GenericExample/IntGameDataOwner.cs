namespace Essential.Core.Memory.GenericExample
{
	/// <summary>
	/// Serialized version of a GameDataOwner holding a single integer value.
	/// </summary>
	public class IntGameDataOwner : DataOwnerBase<IntGameData>
	{
		/// <summary>
		/// Update is used to constantly modify own state. 
		/// </summary>
		public void Update()
		{
			Data.Index++;
		}
	};
}
