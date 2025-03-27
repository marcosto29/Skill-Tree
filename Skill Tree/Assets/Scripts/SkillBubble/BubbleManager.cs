using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BubbleManager : MonoBehaviour
{
    NTree<CharacterSkillData> skill;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(ActivateSkill);
    }

    public NTree<CharacterSkillData> Skill
    {
        get
        {
            return skill;
        }
        set
        {
            transform.position = value.info.position;
            displayedSkill.GetComponent<DisplayManager>().Build(value.info.description);//pass the information to the manager

            Image skillImage = GetComponent<Image>();//Load the image of the skill from Resources
            skillImage.sprite = Resources.Load<Sprite>("Sprites/" + TreeManager.Instance.characterName + "/" + value.info.name);
            skillImage.SetNativeSize();
            skill = value;
        }
    }
    [SerializeField] GameObject displayedSkill;

    private void ActivateSkill()
    {
        displayedSkill.SetActive(true);
    }
}
