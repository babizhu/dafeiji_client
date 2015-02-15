using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
    float speed = 3;
    void Awake()
    {
        init();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        fly();
    }

    protected void init()
    {
        
        //print("offsetPosition.x=" + offsetPosition.x);
       
    }

    protected void fly()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);

        Vector3 pos = transform.position;
        if (pos.y < -5.46f || pos.y > 5.7 || pos.x > 3.2f || pos.x < -3.2f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {

            Destroy(coll.gameObject);
            //StartCoroutine(loadLoseScene());
            Application.LoadLevel("lose");

        }

    }
 
}
