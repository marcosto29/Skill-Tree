using UnityEngine;

[System.Serializable]
public class CharacterSkillData {
    public string name;
    public bool unlocked;
    public string description;
    public SerializableVector3 position;
    public CharacterSkillData(string n, bool u, string des, SerializableVector3 pos)
    {
        name = n;
        unlocked = u;
        description = des;
        position = pos;
    }
}

//personal vector3 class to manage better the information of the position
//since the native one on unity hava a lot of useless (at the moment) information
[System.Serializable]
public class SerializableVector3
{
    public float x;
    public float y;
    public float z;

    public SerializableVector3(float x1, float y1, float z1)
    {
        x = x1;
        y = y1;
        z = z1;
    }

    public static implicit operator Vector3(SerializableVector3 sv) => new(sv.x, sv.y, sv.z);//easier way to manage the data with vectors
    public static implicit operator SerializableVector3(Vector3 sv) => new(sv.x, sv.y, sv.z);
}
