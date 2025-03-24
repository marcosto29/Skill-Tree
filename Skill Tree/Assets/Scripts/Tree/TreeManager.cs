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
        Camera.main.transform.position = new Vector3(0, 0, Camera.main.transform.position.z);
        //when the manager its called a parameter with the name of th character which wants the tree builded must be passed
        //Once it has the character name, it will acces the JSON of this character to take the skills and built a tree with them
        BuildTree(Rebuild(JsonManager.JsonReader<NTree<CharacterSkillData>>("Skills/Skill" + characterName), null));
        backArrow.gameObject.SetActive(true);
    }

    private void BuildTree(NTree<CharacterSkillData> node)//Recursive method to create the tree
    {
        //Create Bubble through the prefab
        GameObject bubble = Instantiate(bubblePrefab, transform);
        bubble.GetComponent<BubbleManager>().Skill = node.info;
        bubble.name = node.info.name;

        if (node.father != null)
        {
            LineRenderer link = bubble.GetComponent<LineRenderer>();
            link.SetPosition(0, node.father.info.position);
            link.SetPosition(1, node.info.position);
        }

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

    //to avoid circular loops when writing on the JSON the father reference is lost
    //therefore this function allows the tree to be rebuild including the father
    NTree<CharacterSkillData> Rebuild(NTree<CharacterSkillData> node, NTree<CharacterSkillData> father)
    {
        if (father != null)
            node.father = father;//Adding the father manually since the children are safed correctly on the JSON therefore an Addchild is unnecessary

        if (node.children.Count > 0)
        {
            foreach (NTree<CharacterSkillData> n in node.children)
            {
                Rebuild(n, node);
            }
        }
        return node;
    }
}
