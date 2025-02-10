using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class CharacterSelect : MonoBehaviour
{
    Dictionary<string, bool> characters;
    public GameObject buttonPrefab;
    public GameObject skillPrefab;
    public SkillTreeManager tree;
    void Awake()
    {
        characters = JsonManager.JsonReader<Dictionary<string, bool>>("Characters");
        int i = 0;
        int j = 0;
        i += characters.Count(chara => chara.Value);//use linq to check how many characters are playable
        foreach (KeyValuePair<string, bool> chara in characters)
        {
            if (chara.Value == true)
            {
                //button to load the tree, right now hardcoded
                Sprite sprite = Resources.Load<Sprite>("Sprites/" + chara.Key + "/" + chara.Key);

                GameObject buttonSelecter = Instantiate(buttonPrefab, transform);
                buttonSelecter.GetComponentInChildren<CharacterSelector>().character = chara.Key;
                buttonSelecter.transform.name = "a";
                buttonSelecter.transform.position = new Vector3(((float)1/i * 210 * j) + ((float)1/i * 210 / 2) - 100, 0, 0);

                Button refe = buttonSelecter.GetComponentInChildren<Button>();
                refe.image.sprite = sprite;
                refe.image.SetNativeSize();
                j++;
            }
        }
    }
}
