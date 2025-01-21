using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisableGameObject : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
            if (rayHit.collider == null) gameObject.SetActive(false);
        }
    }
}
