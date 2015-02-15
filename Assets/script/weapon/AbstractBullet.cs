using UnityEngine;
using System.Collections;

public abstract class AbstractBullet : MonoBehaviour
{

    public AudioClip fireSound;

    private float speed = 10;
    private int damage = 20;

    /**
     * 子弹是否朝上发射
     */
    public bool isUp = true;

    /**
     * 子弹飞行的方向
     */
    private Vector3 direction = Vector3.up;

    //private Vector3 target = new Vector3();
    //private float angle;
    //炮弹的出生地点，考虑到有些武器的炮管比较长
    //private Vector3 offsetPosition = new Vector3();

    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    public int Damage
    {
        set { damage = value; }
        get { return damage; }
    }

    protected void init()
    {
        //target = transform.position;
        //target.y = 100;
        Sound.getInstance().play(fireSound);
        if (!isUp)
        {
            speed /= 4;
            direction = Vector3.down;
        }
    }

    protected void move()
    {
        //transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
        transform.Translate(direction * Time.deltaTime * speed);
        //transform.Translate(Vector3.up, Time.deltaTime * speed);
        Vector3 pos = transform.position;
        if (pos.y < -5.46f || pos.y > 5.7 || pos.x > 3.2f || pos.x < -3.2f)
        {
            Destroy(gameObject);
        }
    }

    protected abstract void doAttack(Collider2D coll);
    public virtual void applyTemplet(BulletTemplet templet)
    {
        speed = templet.Speed;
        damage = templet.Damage;
    }
}
