using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour
{
    Dictionary<string, bool> characters;
    public GameObject buttonPrefab;
    public GameObject skillPrefab;
    void Awake()
    {
        characters = JsonManager.JsonReader<Dictionary<string, bool>>("Characters");
        foreach (KeyValuePair<string, bool> chara in characters)
        {
            if (chara.Value == true)
            {
                //button to load the tree, right now hardcoded
                Sprite sprite = Resources.Load<Sprite>("Sprites/" + chara.Key + "/" + chara.Key);
                Sprite background = Resources.Load<Sprite>("Sprites/" + chara.Key + "/General Background");

                GameObject buttonSelecter = Instantiate(buttonPrefab, transform);

                buttonSelecter.GetComponentInChildren<CharacterSelector>().character = chara.Key;
                buttonSelecter.GetComponentInChildren<Image>().sprite = background;

                Button refe = buttonSelecter.GetComponentInChildren<Button>();
                refe.image.sprite = sprite;

                refe.image.SetNativeSize();
                buttonSelecter.GetComponentInChildren<Image>().SetNativeSize();
            }
        }
    }
}
