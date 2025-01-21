using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public static class JsonManager
{
    public static void JsonWriter(CharacterSkillData A, string name)
    {
        var json = JsonConvert.SerializeObject(A);
        File.WriteAllText(Application.dataPath + "/Skill" + name + ".json", json);
    }

    public static T JsonReader<T>(string filePath)
    {
        var json = File.ReadAllText(Application.dataPath + "/JSON/" + filePath + ".json");
        return JsonConvert.DeserializeObject<T>(json);
    }
    public static void Unlock(string uSkill)
    {
        string json = File.ReadAllText(Application.dataPath + "/JSON/Skills/Skill" + SkillTreeManager.characterName + ".json");
        JObject jsonObject = JObject.Parse(json);


        JArray abilities = (JArray)jsonObject["abilities"];

        foreach (JObject s in abilities)
        {
            if (s["name"].ToString() == uSkill)
            {
                s["unlocked"] = true;
                break;
            }
        }

        string updatedJson = jsonObject.ToString();

        File.WriteAllText(Application.dataPath + "/JSON/Skills/Skill" + SkillTreeManager.characterName + ".json", updatedJson);
    }
}
