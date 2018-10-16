using System;

namespace Essential.Core.Scripts.Memory.Examples
{
    /// <inheritdoc />
    /// <summary>
    /// GameData must be serialized, to show its field within the Unity inspector.
    /// </summary>
    [Serializable]
    public class IntGameData : GameData<int>{}
}