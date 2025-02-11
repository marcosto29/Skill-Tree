using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    public string character;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(SelectCharacter);
    }
    
    private void SelectCharacter()
    {
        SkillTreeManager tree = GetComponentInParent<CharacterSelect>().tree;
        tree.gameObject.SetActive(true);
        tree.characterName = character;
        tree.CreateTree(GetComponentInParent<CharacterSelect>().skillPrefab);
        GetComponentInParent<CharacterSelect>().backArrow.SetActive(true);
        transform.root.gameObject.SetActive(false);
    }
}
