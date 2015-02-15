using UnityEngine;
using System.Collections;

public abstract class AbstractEnemy : MonoBehaviour{
    /**
     * 模板
     */
    protected EnemyTemplet templet;

    /**
     * 被命中后发出的声音
     */
    public AudioClip hit;

    /**
     * 爆炸（死亡）之后发出的声音
     */
    public AudioClip explosionSound;
    /**
     * 飞行速度
     */
    private float speed;

    /**
     * 自身撞击对玩家造成的伤害
     */
    private int attackDamage;

    /**
     * 血条
     */
    protected HealthBar healthBar;

    /**
     * 材质，命中后可闪烁
     */
    protected Material material;
   
    /**
     * 爆炸（死亡）动画
     */
    public GameObject explosion;
	public float Speed
    {
        get
        {
            return speed;
        }
        set
        {
            speed = value;
        }
    }
    /**
     * 敌机的当前血量
     */
    private int hp;
    public int Hp  // read-write instance property
    {
        get
        {
            return hp;
        }
        set
        {
            hp = value;
        }
    }

    private int maxHp;
    public int MaxHp
    {
        get { return maxHp; }
        set { maxHp = value; }
    }

   

       
    /**
     * 敌机死亡，播放动画，增加分数
     */
    abstract public void die();

    /**
     * 开始攻击
     * 
     */
    abstract public void attack();
    /**
     * 应用模板数据
     */
    public virtual void applyTemplet(EnemyTemplet templet)
    {
        Speed = templet.Speed;
        Hp = templet.Hp;
        AttackDamage = templet.AttackDamage;
        maxHp = hp;
    }

    public bool isDie()
    {
        return hp <= 0;
    }

    public int AttackDamage
    {
        set { attackDamage = value; }
        get { return attackDamage; }
    }


    /**
     * 被攻击的时候调用的函数
     */
    public abstract void defend(AbstractPlane plane);

    /**
     * 被玩家子弹命中后执行的闪烁函数
     */
    protected IEnumerator blink()
    {
        
        healthBar.updateHealthBar((float)Hp / MaxHp);

        //setHeathEnabled(true);
        //print(material.color);
        //float tempSpeed = Speed;
        material.color = Color.red;
        //Speed = 0;
        //Animator ani = GetComponent<Animator>();
        //ani.speed = 0;
        //Vector3 pos = transform.localPosition;
        //pos.x += 0.1f;
        //transform.localPosition = pos;
        yield return new WaitForSeconds(0.1f);
        //pos = transform.localPosition;
        //pos.x -= 0.1f;
        //transform.localPosition = pos;
        
        //ani.speed = 1;
        //gameObject.animation.Stop();
        //foreach (AnimationState anim in gameObject.animation)
        //{
        //    if (gameObject.animation.IsPlaying(anim.name))
        //    {
        //        print(anim.name);
        //    }
        //}

        material.color = Color.white;
        //Speed = tempSpeed;
        //yield return new WaitForSeconds(0.15f);
        //setHeathEnabled(false);
    }
    
}
	
