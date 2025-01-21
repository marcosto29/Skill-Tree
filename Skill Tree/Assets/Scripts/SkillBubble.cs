using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillBubble : MonoBehaviour
{
    GameObject displayedSkill;
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
            transform.position = value.position;
            displayedSkill.transform.position = value.position;
            displayedSkill.GetComponentInChildren<TextMeshProUGUI>().text = value.description;
            displayedSkill.GetComponentInChildren<UnlockSkill>().skillName = value.name;
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
