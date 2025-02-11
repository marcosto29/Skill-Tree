using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillTreeManager : MonoBehaviour //There is only going to be one Tree Manager on the scene
{
    public Dictionary<string, Sprite> sprites;
    public CharacterSkillData characterSkills;
    public string characterName;

    public void CreateTree(GameObject skillPrefab)
    {
        characterSkills = JsonManager.JsonReader<CharacterSkillData>("Skills/" + "Skill" + characterName);
        sprites = new();
        sprites.Add("Background", Resources.Load<Sprite>("Sprites/" + characterName + "/Background"));
        sprites.Add("Button", Resources.Load<Sprite>("Sprites/" + characterName + "/Button"));
        int i = 0;
        int j = 0;
        i += characterSkills.abilities.Length;
        foreach (Skill s in characterSkills.abilities)
        {
            GameObject bubble = Instantiate(skillPrefab, transform);
            bubble.transform.position = new Vector3(((float)1 / i * 210 * j) + ((float)1 / i * 210 / 2) - 100, 0, 0);//hardcoded values
            bubble.transform.name = s.name;
            bubble.GetComponentInChildren<SkillBubbleManager>().Skill = s;
            j++;
        }
    }

    public void OnDisable()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
