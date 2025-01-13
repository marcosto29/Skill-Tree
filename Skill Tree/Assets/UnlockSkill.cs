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
        unlock = GetComponent<Button>();
        unlock.onClick.AddListener(() => JsonManager.Unlock(this));
    }
}
