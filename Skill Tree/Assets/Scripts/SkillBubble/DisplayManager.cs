using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;

public class DisplayManager : MonoBehaviour
{
    public GraphicRaycaster raycaster;
    EventSystem eventSystem;
    [SerializeField] Button unlock;

    private void OnEnable()
    {
        SkillBubbleManager bubbleManager = GetComponentInParent<SkillBubbleManager>();

        if(bubbleManager.Skill.GetData().unlocked == true || (bubbleManager.Skill.GetData().father != "None" && bubbleManager.Skill.GetFather().GetData().unlocked == false)) unlock.gameObject.SetActive(false);
        else unlock.gameObject.SetActive(true);
    }
    void Update()
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
