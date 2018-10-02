using UnityEngine;

namespace Essential.Core.DataStorage.Json
{
    public class SerializableJson : ISerializableJson
    {
        public string Serialize()
        {
            return JsonUtility.ToJson(this);
        }

        public void Deserialize(string json)
        {
            JsonUtility.FromJsonOverwrite(json, this);
        }
    }
}
