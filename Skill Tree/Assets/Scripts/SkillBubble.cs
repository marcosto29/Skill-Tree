using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillBubble : MonoBehaviour
{
    GameObject descriptionBox;
    Button display;
    public Sprite Backgorund
    {
        get
        {
            return descriptionBox.GetComponentInChildren<Image>().sprite;
        }
        set
        {
            Image background = descriptionBox.GetComponentInChildren<Image>();
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
            descriptionBox.GetComponentInChildren<TextMeshProUGUI>().text = value.description;
            skill = value;
        }
    }
    private void Awake()
    {
        descriptionBox = transform.GetChild(0).gameObject;
        descriptionBox.SetActive(false);

        display = GetComponent<Button>();
        uiSprite = GetComponent<Image>();
        display.onClick.AddListener(DisplaySkill);
    }

    private void DisplaySkill()
    {
        descriptionBox.SetActive(true);
    }
}
