using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Skill
{
    public string name;
    public bool unlocked;
    public string description;
    public string path;
    public Vector3 position;

    public Skill(bool u, string descr, string n, string p, Vector3 pos)
    {
        unlocked = u;
        description = descr;
        name = n;
        path = p;
        position = pos;
    }
}
