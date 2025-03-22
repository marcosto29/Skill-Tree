using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class DisplayManager : MonoBehaviour
{
    GraphicRaycaster raycaster;
    EventSystem eventSystem;
    public TextMeshProUGUI descriptionText;
    public GameObject unlockButton;
    public Image backgroundImage;

    public void Start()
    {
        raycaster = GetComponentInParent<GraphicRaycaster>();
    }
    public void Build(string text, bool unlocked)
    {
        //Build the displayed bubble skill with the info from the bubble manager
        descriptionText.text = text;//putting the description text from the JSON
        
        backgroundImage.sprite = Resources.Load<Sprite>("Sprites/" + TreeManager.Instance.characterName + "/Background");//loading the background image
        backgroundImage.SetNativeSize();

        unlockButton.GetComponent<UnlockManager>().unlocked = unlocked;//passing to the unlock button the information needed
    }

    private void OnEnable()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);//active each child individually since it can be deactivated by default
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Detect left mouse click
        {
            DetectUIElement();
        }
    }

    void DetectUIElement()
    {
        PointerEventData pointerData = new (eventSystem);
        pointerData.position = Input.mousePosition;

        List<RaycastResult> results = new();
        raycaster.Raycast(pointerData, results);

        if (!results.Any(result => result.gameObject == transform.GetChild(0).gameObject))
            gameObject.SetActive(false);
    }
}
