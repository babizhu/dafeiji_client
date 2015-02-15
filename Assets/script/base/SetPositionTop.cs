using UnityEngine;
using System.Collections;

/**
 * 把输入gameObject顶对齐
 */
public class SetPositionTop : MonoBehaviour {

    

	// Use this for initialization
	void Start () {
        GameCamera gc = Camera.main.GetComponent<GameCamera>();
        transform.position = new Vector3(0, gc.realDevHeight, 0);
        //print(transform.position);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
