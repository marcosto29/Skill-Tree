using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTreeSceneActivator : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == this.transform) SceneManager.ChangeScene("TreeSkill");
            }
        }
    }
}
