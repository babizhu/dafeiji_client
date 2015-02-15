using UnityEngine;
using System.Collections;

public class AbstractBoss : AbstractEnemy {

    public GameObject boss;
    private Player player;

    private ScoreManager scoreManager;
    
	void Start () {
        material = gameObject.renderer.material;
        //player = GameObject.Find("player").GetComponent<Player>();
        healthBar = GetComponentInChildren<HealthBar>();

        MaxHp = Hp = 1000;
        scoreManager = GameObject.Find("score").GetComponent<ScoreManager>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        
	}

    public override void die()
    {
        Instantiate(explosion, transform.position, transform.rotation);
        Sound.getInstance().play(explosionSound);
        if (boss != null)
        {
            Instantiate(boss, transform.position, transform.rotation);
        }
        Destroy(gameObject);

        scoreManager.addNumber(20);
        //player.addScore(3);
        //enemyDestroy();
    }

    

    public override void attack()
    {
        // AudioSource.PlayClipAtPoint(hitTarget, new Vector3());
        
        Sound.getInstance().play(hit);

        
    }

    public override void defend(AbstractPlane plane )
    {
        //print("Hp=" + Hp + " arrow.Attack=" + arrow.Attack);
        //Hp -= plane.Attack;
        Hp -= 10;
        //print("Hp="+ Hp);
        if (isDie())
        {
            die();
            
        }
        else
        {
             healthBar.updateHealthBar((float)Hp / MaxHp);
           //StartCoroutine(blink());
        }
        //print("enemy hp is " + monster.Hp);
    }

    
}
