using UnityEngine;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() => SceneManager.ChangeScene("Central"));     
    }
    public void BackTree()
    {
        GetComponent<Button>().image.sprite = Resources.Load<Sprite>("Sprites/" + TreeManager.Instance.characterName + "/Back Button");
        GetComponent<Button>().onClick.RemoveAllListeners();
        GetComponent<Button>().onClick.AddListener(BackSelect);
    }
    void BackSelect()
    {
        TreeManager.Instance.DestroyTree();
        Select.Instance.CreateSelect();
        GetComponent<Button>().image.sprite = Resources.Load<Sprite>("Sprites/Back");
        GetComponent<Button>().onClick.RemoveAllListeners();
        GetComponent<Button>().onClick.AddListener(() => SceneManager.ChangeScene("Central"));
    }
}
