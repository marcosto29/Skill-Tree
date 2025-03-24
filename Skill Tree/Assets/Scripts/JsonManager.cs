using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using System;

public static class JsonManager
{
    public static void JsonWriter<T>(T data, string filePath)//write a whole JSON from scratch
    {
        var json = JsonConvert.SerializeObject(data, Formatting.Indented, new JsonSerializerSettings//to avoid loops given a certain data structure such as tree
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        });
        File.WriteAllText(Application.dataPath + "/JSON/" + filePath + ".json", json);
    }

    public static T JsonReader<T>(string filePath)//Read on a JSON
    {
        var json = File.ReadAllText(Application.dataPath + "/JSON/" + filePath + ".json");
        return JsonConvert.DeserializeObject<T>(json);
    }

    public static void Update<T>(Action<T, string> fun, string key)//Unlock the skill
    {
        T jsonObj = JsonReader<T>("Skills/Skill" + TreeManager.Instance.characterName);
        fun(jsonObj, key);
        JsonWriter(jsonObj, "Skills/Skill" + TreeManager.Instance.characterName);
    }
}
