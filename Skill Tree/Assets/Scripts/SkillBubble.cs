using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillBubble : MonoBehaviour
{
    public GameObject displayedSkill;
    Button display;
    public Sprite Backgorund
    {
        get
        {
            return displayedSkill.GetComponentInChildren<Image>().sprite;
        }
        set
        {
            Image background = displayedSkill.GetComponentInChildren<Image>();
            background.sprite = value;
            background.SetNativeSize();
        }
    }
    Image uiSprite;
    public Sprite UiSprite
    {
        get
        {
            return uiSprite.sprite;
        }
        set
        {
            uiSprite.sprite = value;
            uiSprite.SetNativeSize();
        }
    }
    Skill skill;
    public Skill Skill
    {
        get
        {
            return skill;
        }
        set
        {
            displayedSkill.GetComponentInChildren<TextMeshProUGUI>().text = value.description;
            
            skill = value;
        }
    }
    private void Awake()
    {
        displayedSkill = transform.GetChild(0).gameObject;
        displayedSkill.SetActive(false);

        display = GetComponent<Button>();
        uiSprite = GetComponent<Image>();

        display.onClick.AddListener(DisplaySkill);
    }

    private void DisplaySkill()
    {
        displayedSkill.SetActive(true);
    }
}
