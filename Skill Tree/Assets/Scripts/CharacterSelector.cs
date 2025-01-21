using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    public string character;
    public GameObject skillPrefab;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(SelectCharacter);
    }
    
    private void SelectCharacter()
    {
        SkillTreeManager.characterName = character;
        SkillTreeManager.CreateTree(skillPrefab);
        Destroy(transform.root.gameObject);
    }
}
