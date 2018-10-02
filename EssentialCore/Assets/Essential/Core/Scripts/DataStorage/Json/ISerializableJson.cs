namespace Essential.Core.DataStorage.Json
{
    /// <summary>
    /// Allow data serialization from and to json. 
    /// </summary>
    public interface ISerializableJson
    {
        /// <summary>
        /// Serialize data object to json.
        /// </summary>
        /// <returns>Json string</returns>
        /// <example>
        /// return JsonUtility.ToJson(this);
        /// </example>
        string Serialize();
        
        /// <summary>
        /// Deserialize data object from json.
        /// </summary>
        /// <param name="json">Json string</param>
        /// <example>
        /// JsonUtility.FromJson<AudioMixerData>(json);
        /// </example>
        void Deserialize(string json);
    }
}
