using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockManager : MonoBehaviour
{
    //since the unlock parameter changes through execution there cant be a variable that holds the value 
    //all the skill needs to be taken when needed
    NTree<CharacterSkillData> node;

    private void OnEnable()
    {
        node = GetComponentInParent<BubbleManager>().Skill;//every time the button is activated it checks the father
        if (node.info.unlocked || (node.father != null && node.father.info.unlocked == false)) 
            gameObject.SetActive(false);
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
        node.info.unlocked = true;
        JsonManager.Update<NTree<CharacterSkillData>>(UnlockSkillBubble, node.info.name);//Unlock the skill on the JSON
        gameObject.SetActive(false);//when the skill is unlocked rewrite the JSON to Update the info and deactivate the button
    }

    public static void UnlockSkillBubble(NTree<CharacterSkillData> tree, string key)
    {
        if (tree.info.name == key)
        {
            tree.info.unlocked = true;
            return;
        }

        foreach (NTree<CharacterSkillData> c in tree.children)
            UnlockSkillBubble(c, key);
    }
}
