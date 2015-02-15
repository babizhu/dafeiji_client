using UnityEngine;
using System.Collections;

public class BulletTemplet
{
    private int id;
    private int damage;
    private string name;
    private float speed;
    private string prefab;
    //private Vector3 offsetPosition = new Vector3();    
    

    public int Id
    {
        set { id = value; }
        get { return id; }
    }
    public int Damage
    {
        get { return damage; }
        set { damage = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    public string Prefab
    {
        set { prefab = value; }
        get { return prefab; }
    }
   
    //public Vector3 OffsetPosition{
    //    set { offsetPosition = value; }
    //    get { return offsetPosition; }
    //}
    
}
