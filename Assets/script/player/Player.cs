using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    
    Vector3 distance =Vector3.zero;//手指第一次点击的时候和飞机的距离
    float realDevHeighBorder, realDevWidthBorder;//屏幕真实的边界
	// Use this for initialization
	void Start () {
        GameCamera gc = Camera.main.GetComponent<GameCamera>();
        realDevHeighBorder = gc.top - GetComponent<Renderer>().bounds.extents.y;
        //realDevWidthBorder = gc.right - GetComponent<Renderer>().bounds.extents.x;
        //realDevHeighBorder = gc.realDevHeight - GetComponent<Renderer>().bounds.extents.y;
        realDevWidthBorder = gc.left - GetComponent<Renderer>().bounds.extents.x;
        //print("realDevWidth=" + gc.realDevWidth + " realDevWidthBorder="+realDevWidthBorder);
        

	}
	
	// Update is called once per frame
	void Update () {

        #if UNITY_EDITOR 
        if (Input.GetMouseButton(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
            checkBorder(ref pos);
            
            
            transform.position = pos;
        }
#endif
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (Input.GetTouch(0).phase != TouchPhase.Moved)
            {
                
                
                distance = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 0f)) - new Vector3(transform.position.x, transform.position.y, 0f);
                distance.z = 0;
            }
            else
            {
                


                //Vector3 lastWorldPos = Camera.main.ScreenToWorldPoint(this.lastTouchPos);
                Vector3 currWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 0f));

                Vector3 pos= currWorldPos - distance;
                pos.z = transform.position.z;

                checkBorder(ref pos);
                transform.position = pos;

            }

            
        }
        
        /*if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved))
        {
            touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            Vector3 xx = new Vector3(touchDeltaPosition.x * Speedx, touchDeltaPosition.y * Speedy, 0);
            transform.position += xx;
            
        }
        

        int touchCount = Input.touchCount;
        if (touchCount != 0 )
        {
            Touch touch = Input.GetTouch(0);


            Vector3 lastWorldPos = Camera.main.ScreenToWorldPoint(this.lastTouchPos);
            Vector3 currWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 0f));


            lastWorldPos.z = 0f;
            currWorldPos.z = 0f;


            Vector3 direct = lastWorldPos - currWorldPos;
            if (direct.magnitude > delaySpeed)
            {
                currWorldPos = currWorldPos + direct.normalized * delaySpeed;


                transform.position = currWorldPos;
                lastTouchPos = touch.position;
            }
        } * */

        //if( Input.touchCount  0 ) 
	}

    private void checkBorder( ref Vector3 pos)
    {
        if (pos.x < -realDevWidthBorder)
        {
            pos.x = -realDevWidthBorder;
        }
        else if (pos.x > realDevWidthBorder)
        {
            pos.x = realDevWidthBorder;
        }

        if (pos.y < -realDevHeighBorder)
        {
            pos.y = -realDevHeighBorder;
        }
        else if (pos.y > realDevHeighBorder)
        {
            pos.y = realDevHeighBorder;
        }
    }
    void FixedUpdate()
    {

      /*
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            transform.Translate(new Vector2(transform.position.x+touchDeltaPosition.x * Speed, transform.position.y+touchDeltaPosition.y * Speed));
            
        }
       * */

        
    }


    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "enemy")
        {

            Destroy(gameObject);
            StartCoroutine(loadLoseScene());

        }

    }

    /**
     * 切换失败场景，好像无需延时
     */
    private IEnumerator loadLoseScene()
    {
        Application.LoadLevel("lose");

        yield return new WaitForSeconds(0.1f);
        Application.LoadLevel("lose");
        print(222222222222);
    }
}
