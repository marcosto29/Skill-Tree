using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTreeManager : MonoBehaviour
{
    public GameObject skillPrefab;
    public Dictionary<string, Sprite> sprites;
    public CharacterSkillData character;
    private void Awake()
    {
        character = JsonManager.JsonReader("Judas");
        sprites = new();
        foreach(Skill s in character.abilities)//preload the sprites
        {
            sprites.Add(s.name, Resources.Load<Sprite>("Sprites/" + character.name + "/" + s.name));
        }
        sprites.Add("Background", Resources.Load<Sprite>("Sprites/" + character.name + "/Background"));
    }
    void Start()
    {
        foreach(Skill s in character.abilities)
        {
            GameObject bubble = Instantiate(skillPrefab, transform);
            bubble.transform.name = s.name;

            SkillBubble skill = bubble.GetComponentInChildren<SkillBubble>();
            skill.Skill = s;

            skill.UiSprite = sprites[s.name];
            skill.Backgorund = sprites["Background"];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
