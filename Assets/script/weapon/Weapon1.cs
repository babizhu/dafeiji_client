using UnityEngine;
using System.Collections;

public class Weapon1 : AbstractPlane
{
    Vector3 bulletPos;
    public string bulletResource;
    void Start()
    {
        //player = GameObject.Find("player").GetComponent<Player>();
        
        Bullet = Resources.Load("bullet/" + bulletResource) as GameObject;
        
        
    }
    void FixedUpdate()
    {
        if (!Pause.IS_PAUSE() )
        {
            // print("FixedUpdate");
            fire();
        }

    }



    protected override void doNormalAttack()
    {
        bulletPos = transform.position;
        bulletPos.y += 0.5f;
        Instantiate(Bullet, bulletPos, transform.rotation);
        //arrowObj.GetComponent<AbstractBullet>().applyTemplet(BulletTemplet);

        
        //Instantiate(Arrow, transform.position, transform.rotation);
    }
}
