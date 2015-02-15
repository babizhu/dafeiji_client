using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {

    public GameObject bg;
    private Transform[] bgs = new Transform[3];
    private float height;
    public float speed = 1;

    /**
     * 记录当前Y值最小的背景图片在数组中的位置
     */
    private int index = 0;
    // Use this for initialization
    void Start()
    {
        height = bg.renderer.bounds.size.y;
        Vector3 pos = Vector3.zero;
        pos.y = -height;
        for (int i = 0; i < bgs.Length; i++)
        {
            Transform trm = (Instantiate(bg, pos, Quaternion.identity) as GameObject).transform;
            trm.parent = transform;

            bgs[i] = trm;
            pos.y += height;
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);


        /* for (int i = 0; i < bgs.Length; i++)
         {
            
             Vector3 pos = bgs[i].position;
             if ( pos.y < -height)
             {
                 pos.y += 3 * height;

                 bgs[i].position = pos;
                 print("i=" + i);
                 break;
             }
         }
         
         **/

        Transform minY = bgs[index % bgs.Length];
        //print(minY.position.y);


        Vector3 pos = minY.position;
        if (pos.y < -height-1)
        {
            pos.y += bgs.Length * height;

            minY.position = pos;
            index++;

        }
        //print(bgs[0].transform.position.y);

    }
}

