using UnityEngine;
using System.Collections;


/**
 * 所有飞机的基类
 */
public abstract class AbstractPlane : MonoBehaviour {

    private GameObject bullet;
    protected Player player;
    protected int attack;
    protected int hp;
    protected int hpMax;




    public int Attack
    {
        set { attack = value; }
        get { return attack; }
    }
    public GameObject Bullet
    {
        set { bullet = value; }
        get { return bullet; }
    }
    private BulletTemplet bulletTemplet;
    public BulletTemplet BulletTemplet
    {
        set { bulletTemplet = value; }
        get { return bulletTemplet; }
    }

    /**
     * 当前冷却时间
     */
    private float currentCoolDown;
    public float CurrentCoolDown
    {
        get { return currentCoolDown; }
        set { currentCoolDown = value; }
    }

    /**
     * 冷却时间
     */
    private float coolDown;
    public float CoolDown
    {
        get { return coolDown; }
        set { coolDown = value; }
    }


    private int needSp;
    public int NeedSp
    {
        set { needSp = value; }
        get { return needSp; }
    }

    /**
     * 开火
     */
    protected void fire()
    {
        if (currentCoolDown > 0)
        {
            currentCoolDown -= Time.deltaTime;
            return;
        }

        

        doNormalAttack();
        currentCoolDown = 0.1f;
        
        
    }

    protected abstract void doNormalAttack();

    public virtual void applyTemplet(WeaponTemplet templet)
    {
        coolDown = templet.CoolDown;
        //needSp = templet.NeedSp;
        //print("coolDown=" + coolDown);
    }  
}
