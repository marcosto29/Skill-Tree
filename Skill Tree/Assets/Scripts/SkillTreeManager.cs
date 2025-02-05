using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillTreeManager : MonoBehaviour //There is only going to be one Tree Manager on the scene
{
    public static Dictionary<string, Sprite> sprites;
    public static CharacterSkillData characterSkills;
    public static string characterName;

    public static void CreateTree(GameObject skillPrefab)
    {
        characterSkills = JsonManager.JsonReader<CharacterSkillData>("Skills/" + "Skill" + characterName);
        sprites = new();
        sprites.Add("Background", Resources.Load<Sprite>("Sprites/" + characterName + "/Background"));
        sprites.Add("Button", Resources.Load<Sprite>("Sprites/" + characterName + "/Button"));

        foreach (Skill s in characterSkills.abilities)
        {
            GameObject bubble = Instantiate(skillPrefab);
            bubble.GetComponentInChildren<SkillBubbleManager>().Skill = s;
            bubble.transform.name = s.name;
        }
    }
}
