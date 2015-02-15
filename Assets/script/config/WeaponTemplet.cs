using UnityEngine;
using System.Collections;

public class WeaponTemplet
{
    private int id;
    private float coolDown;
    private string name;



    public int Id
    {
        set { id = value; }
        get { return id; }
    }
    public float CoolDown
    {
        get { return coolDown; }
        set { coolDown = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

}
