using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Skill
{
    public string name;
    public bool unlocked;
    public string description;
    public Vector3 position;

    public Skill(bool u, string descr, string n, Vector3 pos)
    {
        unlocked = u;
        description = descr;
        name = n;
        position = pos;
    }
}
