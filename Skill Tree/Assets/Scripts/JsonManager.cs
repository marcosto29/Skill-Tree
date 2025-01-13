using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public static class JsonManager
{
    public static void JsonWriter(CharacterSkillData A)
    {
        var json = JsonConvert.SerializeObject(A);
        File.WriteAllText(Application.dataPath + "/Skill" + A.name + ".json", json);
    }
    
    public static CharacterSkillData JsonReader(string character)
    {
        var json = File.ReadAllText(Application.dataPath + "/Skill" + character + ".json");
        return JsonConvert.DeserializeObject<CharacterSkillData>(json);
    }

    public static void Unlock(UnlockSkill uSkill)
    {
        string json = File.ReadAllText(Application.dataPath + "/Skill" + uSkill.GetComponentInParent<SkillTreeManager>().character.name + ".json");
        JObject jsonObject = JObject.Parse(json);

        JArray abilities = (JArray)jsonObject["abilities"];

        foreach (JObject s in abilities)
        {
            if (s["name"].ToString() == uSkill.GetComponentInParent<SkillBubble>().Skill.name)
            {
                s["unlocked"] = true;
                break;
            }
        }

        string updatedJson = jsonObject.ToString();

        File.WriteAllText(Application.dataPath + "/Skill" + uSkill.GetComponentInParent<SkillTreeManager>().character.name + ".json", updatedJson);
        Debug.Log("Done");
    }
}
