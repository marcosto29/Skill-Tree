using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CharacterSelector : MonoBehaviour//Button to activate the Tree
{
    public string character;//character whose tree is gonna be builded
    void Start()
    {
        Button button = GetComponent<Button>();
        button.image.sprite = Resources.Load<Sprite>("Sprites/" + character + "/" + character);//load the sprite on the button
        button.image.SetNativeSize();

        GetComponent<Button>().onClick.AddListener(SelectCharacter);
    }

    private void SelectCharacter()
    {
        //call the Tree on the Scene and build it
        Select.Instance.DestroySelect();      
        TreeManager.Instance.characterName = character;//save the name on the variable to be accesible for other objects
        TreeManager.Instance.CreateTree();//create the tree with the name
    }
}
