using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
public class UnlockSkill : MonoBehaviour
{
    Button unlock;
    private void Awake()
    {
        SkillBubbleManager bubbleManager = GetComponentInParent<SkillBubbleManager>();

        if (bubbleManager.Skill.unlocked == true) gameObject.SetActive(false);
        unlock = GetComponent<Button>();
        unlock.onClick.AddListener(() => {
            JsonManager.Unlock(bubbleManager.Skill.name, SkillTreeManager.characterName);
            gameObject.SetActive(false);
        });
    }
}
