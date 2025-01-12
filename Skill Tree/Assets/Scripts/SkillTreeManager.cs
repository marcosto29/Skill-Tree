using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTreeManager : MonoBehaviour
{
    public GameObject canvas;
    public GameObject skillPrefab;
    void Start()
    {
        SkillTreeData J = JsonManager.ReadJson("Judas");

        foreach(Skill A in J.abilities)
        {
            GameObject bubble = Instantiate(skillPrefab, canvas.transform);
            bubble.transform.name = A.name;

            SkillBubble skill = bubble.GetComponent<SkillBubble>();

            skill.Skill = A;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
