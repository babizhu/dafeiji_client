using UnityEngine;
using System.Collections;

/**
 * 直上直下的敌人
 *
 */
public class NormalEnemy : AbstractEnemy {

    public EnemyTemplet templet;
    private ScoreManager scoreManager;


    void Start()
    {
        material = gameObject.renderer.material;    
        healthBar = GetComponentInChildren<HealthBar>();
        MaxHp =  Hp = 100;

       Speed = Random.Range(3, 6);
       scoreManager = GameObject.Find("score").GetComponent<ScoreManager>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 pos = transform.position;
        pos.y -= Speed* Time.deltaTime;
        if (pos.y < -5.46f)
        {
            pos.y = 6.09f;
            pos.x = Random.Range(-2.68f,2.68f);
        }
        transform.position = pos;
	}

    public override void die()
    {
        Instantiate(explosion, transform.position, transform.rotation);
        //healthBar.setHeathEnabled(false);
        //anim.enabled = true;
        Vector3 pos = transform.position;
     
        
            pos.y = 6.09f;
            transform.position = pos;
            MaxHp += 10;
            Hp = MaxHp;
        
        //Destroy(gameObject);
        Sound.getInstance().play(explosionSound);
        scoreManager.addNumber(3);
        //enemyDestroy();
    }



    public override void attack()
    {
        // AudioSource.PlayClipAtPoint(hitTarget, new Vector3());

        Sound.getInstance().play(hit);


    }

    public override void defend(AbstractPlane plane)
    {
        
        //Hp -= plane.Attack;
        Hp -= 10;
        //print("Hp="+ Hp);
        if (isDie())
        {
            die();

        }
        else
        {
            StartCoroutine(blink());
        }
        
    }


}