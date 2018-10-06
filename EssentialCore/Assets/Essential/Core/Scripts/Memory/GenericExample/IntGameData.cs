using System;

namespace Essential.Core.Memory.GenericExample
{
    /// <inheritdoc />
    /// <summary>
    /// GameData must be serialized, to show its field within the Unity inspector.
    /// </summary>
    [Serializable]
    public class IntGameData : GameData<int>{}
}