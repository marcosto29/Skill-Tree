using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
public class UnlockSkill : MonoBehaviour
{
    Button unlock;
    private void OnEnable()
    {
        SkillBubbleManager bubbleManager = GetComponentInParent<SkillBubbleManager>();

        if (bubbleManager.Skill.unlocked == true ||  (bubbleManager.Skill.father != "None" && GetComponentInParent<SkillTreeManager>().skills[bubbleManager.Skill.father].unlocked == false)) gameObject.SetActive(false);
        print(GetComponentInParent<SkillTreeManager>().skills[bubbleManager.Skill.father].unlocked);
        unlock = GetComponent<Button>();
        unlock.onClick.AddListener(() => {
            JsonManager.Unlock(GetComponentInParent<SkillTreeManager>().characterName, bubbleManager.Skill.name);
            gameObject.SetActive(false);
        });
    }
}
