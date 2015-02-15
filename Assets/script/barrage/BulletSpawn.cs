using UnityEngine;
using System.Collections;

public class BulletSpawn : MonoBehaviour {

	// Use this for initialization
    public GameObject bullet;
    Vector3 eulerAngles = Vector3.zero;
    public string barrageType;
	void Start () {
        fire();
	}
	
	// Update is called once per frame
	void Update () {
       // if (Input.GetMouseButtonDown(1))
        {
            //Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);


            //float targetAngle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
            //Vector3 a2bDirection = target - transform.position;//获得一条从弓箭向量尾指向鼠标的向量。

            //eulerAngles.z = Mathf.Rad2Deg * Mathf.Atan(a2bDirection.y / a2bDirection.x) +90;
            //eulerAngles.z = targetAngle-270;
            
            //go.rigidbody2D.velocity = Vector3.up*10;
            //go.rigidbody2D.AddForce()
            //print(eulerAngles);
            
            //StartCoroutine(lineBarrage());
            
            
            
        }
	
	}
    void fire()
    {
        
            StartCoroutine(barrageType);
            //yield return new WaitForSeconds(10);
        
    }
    IEnumerator lineBarrage()
    {
        int count = 3;
        float xOffset = 1.5f;
        
        
        float coldDown = 0.4f;
        for (int n = 0; n < 1000; n++)
        {
            for (int m = 0; m < 15; m++)
            {
                
                Vector3 pos = transform.position;
                float baseX = (1 - count) / 2f * xOffset + pos.x;
                for (int i = 0; i < count; i++)
                {
                    pos.x = baseX + i * xOffset;
                    
                    Instantiate(bullet, pos, transform.rotation);
                    
                }
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(coldDown);
        }
    }

    IEnumerator normalBarrage1()
    {
        int count = 30;
        int anglePerBullet = 6;
        float baseAngle = (1 - count) / 2f * anglePerBullet;
        float baseAngle1 = 40 + baseAngle;
        float baseAngle2 = 40 + baseAngle1;
        float baseAngle3 = 40 + baseAngle2;
        float baseAngle4 = 40 + baseAngle3;
        float baseAngle5 = 40 + baseAngle4;
        float baseAngle6 = 40 + baseAngle5;
        float baseAngle7 = 40 + baseAngle6;
        float baseAngle8 = 40 + baseAngle7;

        float coldDown = 0.3f;

        Vector3 pos1, pos2;
        pos1 = pos2 = transform.position;
        //pos1.x -= 0.5f;
        //pos2.x += 0.5f;
        while (true)
        {
            for (int i = 0; i < count; i++)
            {

                eulerAngles.z = baseAngle + i * anglePerBullet;
                GameObject go = Instantiate(bullet, pos1, Quaternion.Euler(0, 0, eulerAngles.z)) as GameObject;

                eulerAngles.z = baseAngle1 + i * anglePerBullet;
                Instantiate(bullet, pos2, Quaternion.Euler(0, 0, eulerAngles.z));

                eulerAngles.z = baseAngle2 + i * anglePerBullet;
                Instantiate(bullet, pos2, Quaternion.Euler(0, 0, eulerAngles.z));

                eulerAngles.z = baseAngle3 + i * anglePerBullet;
                Instantiate(bullet, pos2, Quaternion.Euler(0, 0, eulerAngles.z));

                eulerAngles.z = baseAngle4 + i * anglePerBullet;
                Instantiate(bullet, pos2, Quaternion.Euler(0, 0, eulerAngles.z));

                eulerAngles.z = baseAngle5 + i * anglePerBullet;
                Instantiate(bullet, pos2, Quaternion.Euler(0, 0, eulerAngles.z));

                eulerAngles.z = baseAngle6 + i * anglePerBullet;
                Instantiate(bullet, pos2, Quaternion.Euler(0, 0, eulerAngles.z));

                eulerAngles.z = baseAngle7 + i * anglePerBullet;
                Instantiate(bullet, pos2, Quaternion.Euler(0, 0, eulerAngles.z));

                eulerAngles.z = baseAngle8 + i * anglePerBullet;
                Instantiate(bullet, pos2, Quaternion.Euler(0, 0, eulerAngles.z));







                yield return new WaitForSeconds(coldDown);
                //
                //go.transform.eulerAngles = eulerAngles;
                //Vector2 target1 = fly(eulerAngles.z);
                //go.transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * 5);


            }
            //baseAngle = -baseAngle;
            //for (int i = 0; i < count; i++)
            //{

              //  eulerAngles.z = baseAngle - i * anglePerBullet;

                //GameObject go = Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, eulerAngles.z)) as GameObject;
                //yield return new WaitForSeconds(coldDown);
                //
                //go.transform.eulerAngles = eulerAngles;
                //Vector2 target1 = fly(eulerAngles.z);
                //go.transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * 5);


            //}
        }
    }
    IEnumerator normalBarrage()
    {
        int count = 5;
        int anglePerBullet = 10;
        float baseAngle = (1 - count) / 2f * anglePerBullet;
        float coldDown = 1f;
        while(true)
        {
            for (int n = 0; n < 3; n++)
            {
                for (int i = 0; i < count; i++)
                {

                    eulerAngles.z = baseAngle + i * anglePerBullet;

                    GameObject go = Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, eulerAngles.z)) as GameObject;
                    
                }
                yield return new WaitForSeconds(coldDown/2);
            }
            yield return new WaitForSeconds(2*coldDown);
        }
    }

    IEnumerator normalBarrage2()
    {
        int count = 7;
        int anglePerBullet = 9;
        float baseAngle = (1 - count) / 2f * anglePerBullet;
        float coldDown = 1f;
        while (true)
        {
            for (int n = 0; n < 3; n++)
            {
                for (int i = 0; i < count; i++)
                {

                    eulerAngles.z = baseAngle + i * anglePerBullet;

                    GameObject go = Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, eulerAngles.z)) as GameObject;

                }
                yield return new WaitForSeconds(coldDown / 3);
                for (int i = 0; i < count; i++)
                {

                    eulerAngles.z = baseAngle + i * anglePerBullet + 4.5f;

                    GameObject go = Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, eulerAngles.z)) as GameObject;

                }
                yield return new WaitForSeconds(coldDown / 3);
                for (int i = 0; i < count; i++)
                {

                    eulerAngles.z = baseAngle + i * anglePerBullet;

                    GameObject go = Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, eulerAngles.z)) as GameObject;

                }
                yield return new WaitForSeconds(coldDown / 1.5f);
            }
            yield return new WaitForSeconds( coldDown*2f);
        }
    }
    
}
