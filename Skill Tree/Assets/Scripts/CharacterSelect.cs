using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour
{
    Dictionary<string, bool> characters;
    static GameObject selectParent;
    public GameObject buttonPrefab;
    void Awake()
    {
        selectParent = new();
        characters = JsonManager.JsonReader<Dictionary<string, bool>>("Characters");
        int i = 0;
        foreach (KeyValuePair<string, bool> chara in characters)
        {
            if (chara.Value == true)
            {
                //button to load the tree, right now hardcoded
                Sprite sprite = Resources.Load<Sprite>("Sprites/" + chara.Key + "/" + chara.Key);
                GameObject buttonSelecter = Instantiate(buttonPrefab, selectParent.transform);
                buttonSelecter.GetComponentInChildren<CharacterSelector>().character = chara.Key;

                Button refe = buttonSelecter.GetComponentInChildren<Button>();

                refe.transform.position = new Vector3(transform.position.x + 1000 * i / characters.Count, 250, 0);
                refe.image.sprite = sprite;
                refe.image.SetNativeSize();
                i++;
            }
        }
    }
}
