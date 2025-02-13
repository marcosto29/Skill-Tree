using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class SkillTreeManager : MonoBehaviour
{
    public Dictionary<string, Sprite> sprites;
    public Dictionary<string, Skill> skills;
    NTree<Skill> skillTree;
    public string characterName;

    public void CreateTree(GameObject skillPrefab)
    {
        sprites = new();
        sprites.Add("Background", Resources.Load<Sprite>("Sprites/" + characterName + "/Background"));
        sprites.Add("Button", Resources.Load<Sprite>("Sprites/" + characterName + "/Button"));
        skills = JsonManager.JsonReader<CharacterSkillData>("Skills/" + "Skill" + characterName).abilities
            .ToDictionary<Skill, string>(a => a.name);
        skillTree = new(skills.Values.FirstOrDefault(skill => skill.father == "None"));
        BuildTree(skillTree, skillPrefab);//create the Tree after fniding the root
    }

    private void BuildTree(NTree<Skill> node, GameObject skillPrefab)
    {
        GameObject bubble = Instantiate(skillPrefab, transform);
        bubble.GetComponent<SkillBubbleManager>().Skill = node;
        if (node.GetData().children.Count > 0)
        {
            foreach (string s in node.GetData().children)
            {
                NTree<Skill> child = new(skills[s]);
                node.AddChild(child);
                BuildTree(child, skillPrefab);
            }
        }
        return;
    }
    public void OnDisable()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
