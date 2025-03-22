using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateSelector : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(BackSelect);
    }
    private void OnEnable()
    {
        GetComponent<Button>().image.sprite = Resources.Load<Sprite>("Sprites/" + TreeManager.Instance.characterName + "/Back Button");
    }
    void BackSelect()
    {
        TreeManager.Instance.DestroyTree();
        Select.Instance.CreateSelect();
        gameObject.SetActive(false);
    }
}
