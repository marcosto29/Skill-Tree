using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCreator : MonoBehaviour
{
    void Start()
    {
        Vector3 position = new Vector3(0, 0, 0);
        CharacterSkillData first = new CharacterSkillData("MINE THERE!", false, "- MINE THERE!.\n\nRaw materials awaits you. \nThrow them to enemies, craft something, EAT THEM", position);
        NTree<CharacterSkillData> fundamentals = new NTree<CharacterSkillData>(first);
        
        Vector3 position2 = new Vector3(100, -100, 0);
        CharacterSkillData first2 = new CharacterSkillData("Eraser", false, "- Eraser.\n\nDelete your enemies", position2);
        NTree<CharacterSkillData> eraser = new NTree<CharacterSkillData>(first2);

        Vector3 position4 = new Vector3(-100, -100, 0);
        CharacterSkillData first4 = new CharacterSkillData("RGB Buckets", false, "- RGB Buckets.\n\nWet your brush on a palette of different colors to add an effect", position4);
        NTree<CharacterSkillData> RGB = new NTree<CharacterSkillData>(first4);

        Vector3 position3 = new Vector3(-100, -200, 0);
        CharacterSkillData first3 = new CharacterSkillData("Secondary Colors", false, "- Secondary Colors.\n\nEven more effects on the enemies", position3);
        NTree<CharacterSkillData> secondary = new NTree<CharacterSkillData>(first3);
        
        Vector3 position5 = new Vector3(150, -200, 0);
        CharacterSkillData first5 = new CharacterSkillData("Renewed Papyro", false, "- Renewed Papyro.\n\nThe only way your art can truly improve", position5);
        NTree<CharacterSkillData> Renewed = new NTree<CharacterSkillData>(first5);
        
        Vector3 position6 = new Vector3(50, -200, 0);
        CharacterSkillData first6 = new CharacterSkillData("Shading", false, "- Shading.\n\nGive shadows to your foes", position6);
        NTree<CharacterSkillData> Shading = new NTree<CharacterSkillData>(first6);

        fundamentals.AddChild(eraser);
        fundamentals.AddChild(RGB);
        RGB.AddChild(secondary);
        eraser.AddChild(Shading);
        eraser.AddChild(Renewed);

        JsonManager.JsonWriter<NTree<CharacterSkillData>>(fundamentals, "Skills/SkillMiner");
    }
}
