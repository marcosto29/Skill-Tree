using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateSelector : MonoBehaviour
{
    [SerializeField] GameObject selector;
    [SerializeField] GameObject tree;
    // Start is called before the first frame update
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(BackSelect);
    }
    private void OnEnable()
    {
        GetComponent<Button>().image.sprite = Resources.Load<Sprite>("Sprites/" + tree.GetComponent<SkillTreeManager>().characterName + "/Back Button");
    }
    void BackSelect()
    {
        tree.SetActive(false);
        selector.SetActive(true);
        gameObject.SetActive(false);
    }
}
