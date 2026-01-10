using PuzzleDungeon.Core.Serializer;
using UnityEngine;

namespace PuzzleDungeon.Unity.Serializer;

public class JsonUtilitySerializer : ISerializer
{
    public string Serialize<T>(T obj)
    {
        return JsonUtility.ToJson(obj);
    }

    public T Deserialize<T>(string data)
    {
        return JsonUtility.FromJson<T>(data);
    }
}