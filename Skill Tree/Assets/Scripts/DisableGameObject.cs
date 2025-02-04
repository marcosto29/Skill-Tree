using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;

public class DisableGameObject : MonoBehaviour
{
    public GraphicRaycaster raycaster;
    EventSystem eventSystem;

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
