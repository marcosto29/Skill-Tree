using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour
{
    public static Select Instance { get; private set; }//Singleton
    Dictionary<string, bool> characters; //A Dictionary to load the characters and know which ones are unlocked and which ones arent
    [SerializeField] GameObject selectorPrefab; //prefab of the selector GameObject
    float positon;
    public BackButton back;
    private void Awake()
    {
        if (Instance != null && Instance != this)//since instance is static is unique
        {
            Destroy(gameObject);//Prevent duplicate instances therefore only one
            return;
        }
        Instance = this;

        characters = JsonManager.JsonReader<Dictionary<string, bool>>("Characters");
        CreateSelect();
    }

    public void CreateSelect()
    {
        Camera.main.transform.position = new Vector3(0, 0, Camera.main.transform.position.z);
        positon = -100;
        foreach (KeyValuePair<string, bool> s in characters)
        {
            if (s.Value)
            {
                //if the character is unlocked create the select Bubble
                GameObject selectBubble = Instantiate(selectorPrefab, transform);
                selectBubble.name = s.Key;
                selectBubble.transform.position += new Vector3(positon, 0, 0);
                selectBubble.GetComponent<CharacterSelector>().character = s.Key;
                positon += 100;
            }
        }
    }

    public void DestroySelect()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
