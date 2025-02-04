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
        if (GetComponentInParent<SkillBubble>().Skill.unlocked == true) gameObject.SetActive(false);
        unlock = GetComponent<Button>();
        unlock.onClick.AddListener(() => {
            JsonManager.Unlock(GetComponentInParent<SkillBubble>().Skill.name);
            gameObject.SetActive(false);
        });
    }
}
