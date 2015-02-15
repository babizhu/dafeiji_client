using UnityEngine;
using System.Collections;

public class WingMove : MonoBehaviour {

    public Transform target;
    float smooth = 15;
    public Vector3 distance = new Vector3();
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (target == null)
        {
            return;
        }
        Vector3 tpos = target.position;
        tpos -= distance;
        transform.position = Vector3.Lerp(
        transform.position, tpos,
        Time.deltaTime * smooth);
	}
}
