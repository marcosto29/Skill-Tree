using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillTreeManager : MonoBehaviour
{
    public static Dictionary<string, Sprite> sprites;
    public static CharacterSkillData characterSkills;
    public static string characterName;


    public static void CreateTree(GameObject skillPrefab)
    {
        characterSkills = JsonManager.JsonReader<CharacterSkillData>("Skills/" + "Skill" + characterName);
        sprites = new();
        foreach (Skill s in characterSkills.abilities)//preload the sprites
        {
            sprites.Add(s.name, Resources.Load<Sprite>("Sprites/" + characterName + "/" + s.name));
        }
        sprites.Add("Background", Resources.Load<Sprite>("Sprites/Background"));

        foreach (Skill s in characterSkills.abilities)
        {
            GameObject bubble = Instantiate(skillPrefab);
            bubble.transform.name = s.name;

            SkillBubble skill = bubble.GetComponentInChildren<SkillBubble>();
            skill.Skill = s;

            skill.UiSprite = sprites[s.name];
            skill.Backgorund = sprites["Background"];
        }
    }
}
