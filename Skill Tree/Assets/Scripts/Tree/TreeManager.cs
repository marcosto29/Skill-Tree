using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeManager : MonoBehaviour
{
    public static TreeManager Instance { get; private set; }//Singleton because there is only one tree
    [SerializeField] GameObject bubblePrefab;
    [SerializeField] ActivateSelector backArrow;
    public string characterName;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null && Instance != this)//since instance is static is unique
        {
            Destroy(gameObject);//Prevent duplicate instances therefore only one tree smanager
            return;
        }
        Instance = this;
    }

    public void CreateTree()
    {
        //when the manager its called a parameter with the name of th character which wants the tree builded must be passed
        //Once it has the character name, it will acces the JSON of this character to take the skills and built a tree with them
        BuildTree(JsonManager.JsonReader<NTree<CharacterSkillData>>("Skills/Skill" + characterName));
        backArrow.gameObject.SetActive(true);
    }

    private void BuildTree(NTree<CharacterSkillData> node)//Recursive method to create the tree
    {
        //Create Bubble through the prefab
        GameObject bubble = Instantiate(bubblePrefab, transform);
        bubble.GetComponent<BubbleManager>().Skill = node.info;
        bubble.name = node.info.name;

        if (node.children.Count > 0)
        {
            foreach (NTree<CharacterSkillData> n in node.children)
            {
                BuildTree(n);
            }
        }
        return;
    }

    //In this approach the tree and the character selector are in the same scene
    //when one activates te other deactivate when deactivating the tree to choose another
    //character all the bubbles are destroyed to let the new ones be created
    public void DestroyTree()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
