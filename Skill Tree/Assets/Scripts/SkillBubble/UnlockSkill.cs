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

        unlock = GetComponent<Button>();
        unlock.onClick.AddListener(() => {
            bubbleManager.Skill.GetData().unlocked = true;
            JsonManager.Unlock(GetComponentInParent<SkillTreeManager>().characterName, bubbleManager.Skill.GetData().name);
            gameObject.SetActive(false);
        });
    }
}
