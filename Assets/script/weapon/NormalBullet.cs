using UnityEngine;
using System.Collections;

public class NormalBullet : AbstractBullet
{

    void Awake()
    {
        init();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        move();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {


    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        doAttack(coll);

    }
    protected override void doAttack(Collider2D coll)
    {
        if ( isUp && coll.tag == "enemy")
        {

            Destroy(gameObject);
            AbstractEnemy enemy = coll.GetComponent<AbstractEnemy>();
            enemy.defend(null);

            return;
        }
        if (!isUp && coll.tag == "Player")
        {
            Destroy(coll.gameObject);
            //StartCoroutine(loadLoseScene());
            Application.LoadLevel("lose");
        }
        
    }

}
