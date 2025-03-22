using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockManager : MonoBehaviour
{
    public bool unlocked;

    // Start is called before the first frame update
    private void OnEnable()
    {
        if (unlocked) gameObject.SetActive(false);//when it activates detects if the skill is unlocked to not activate it
    }

    void Awake()
    {
        Button button = GetComponent<Button>();
        
        button.onClick.AddListener(UnlockSkill);
        
        button.image.sprite = Resources.Load<Sprite>("Sprites/" + TreeManager.Instance.characterName + "/Button");//Load the image button
        button.image.SetNativeSize();
    }

    private void UnlockSkill()
    {
        unlocked = true;
        JsonManager.Unlock(GetComponentInParent<BubbleManager>().Skill.name);//Unlock the skill on the JSON
        gameObject.SetActive(false);//when the skill is unlocked rewrite the JSON to Update the info and deactivate the button
    }
}
