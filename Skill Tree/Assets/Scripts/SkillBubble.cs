using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillBubble : MonoBehaviour
{
    Button display;
    Image uiSprite;
    Skill skill;
    GameObject descriptionBox;
    public Skill Skill
    {
        get
        {
            return skill;
        }
        set
        {
            descriptionBox.GetComponentInChildren<TextMeshProUGUI>().text = value.description;
            uiSprite.sprite = Resources.Load<Sprite>(value.path);
            transform.position = value.position;
            uiSprite.SetNativeSize(); //readjust the image size so that it fits with the sprite
        }
    }
    private void Awake()
    {
        descriptionBox = transform.GetChild(0).gameObject;
        descriptionBox.transform.position = transform.position / 2;
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
