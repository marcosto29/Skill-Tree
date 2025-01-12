using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class JsonManager
{
    public static void WriteJson(SkillTreeData A)
    {
        string json = JsonUtility.ToJson(A, true);//second parameter is to make the object readable
        File.WriteAllText(Application.dataPath + "/Skill" + A.character + ".json", json);
    }

    public static SkillTreeData ReadJson(string character)
    {
        string json = File.ReadAllText(Application.dataPath + "/Skill" + character + ".json");
        SkillTreeData data = JsonUtility.FromJson<SkillTreeData>(json);

        return data;
    }
}
