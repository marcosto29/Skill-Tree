using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillBubbleManager : MonoBehaviour
{
    [SerializeField] GameObject displayedSkill; //Displayed text that shows what the skill does and the unlock button
    [SerializeField] Button display; //Button component to display the above gameobject
    NTree<Skill> skill;

    public NTree<Skill> Skill
    {
        get
        {
            return skill;
        }
        set 
        {
            skill = value;

            transform.position = value.GetData().position;
            transform.name = value.GetData().name;

            displayedSkill.GetComponentInChildren<TextMeshProUGUI>().text = value.GetData().description;//setting up the description text         
            display.image.sprite = Resources.Load<Sprite>("Sprites/" + GetComponentInParent<SkillTreeManager>().characterName + "/" + value.GetData().name);
            display.image.SetNativeSize();
        }
    }

    private void Awake()
    {
        Image displayedImage = displayedSkill.GetComponentInChildren<Image>();//setting up the description background
        displayedImage.sprite = GetComponentInParent<SkillTreeManager>().sprites["Background"];
        displayedImage.SetNativeSize();

        Image buttonImage = displayedSkill.GetComponentInChildren<Button>().image;//setting up the unlocked button image
        buttonImage.sprite = GetComponentInParent<SkillTreeManager>().sprites["Button"];
        buttonImage.SetNativeSize();

        display.onClick.AddListener(DisplaySkill);//setting up the skill button to activate the description
    }

    private void DisplaySkill()
    {
        displayedSkill.SetActive(true);
    }
}
