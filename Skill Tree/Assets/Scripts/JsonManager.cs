using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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

    public static void Unlock(string skill)//Unlock the skill
    {
        NTree<CharacterSkillData> jsonObj = JsonReader<NTree<CharacterSkillData>>("Skills/Skill" + TreeManager.Instance.characterName);
        UnlockSkill(jsonObj, skill);
        JsonWriter(jsonObj, "Skills/Skill" + TreeManager.Instance.characterName);
    }

    private static void UnlockSkill(NTree<CharacterSkillData> tree, string skill)
    {
        if (tree.info.name == skill)
        {
            tree.info.unlocked = true;
            return;
        }

        foreach (NTree<CharacterSkillData> c in tree.children)
            UnlockSkill(c, skill);
    }
}
