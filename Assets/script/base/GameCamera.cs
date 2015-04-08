using UnityEngine;
using System.Collections;

public class GameCamera : MonoBehaviour {

    //主界面上下左右的边界数值
    public float top, bottom, left, right;

    public float realDevHeight, realDevWidth;
    //private float devHeight = 9.6f;
    public float devWidth = 6.4f;
	// Use this for initialization
	void Awake () {
	//float screenHeight = Screen.height;

        //Debug.Log ("screenHeight = " + screenHeight);

        //this.GetComponent<Camera>().orthographicSize = screenHeight / 200.0f;

        realDevHeight = this.GetComponent<Camera>().orthographicSize;

        float aspectRatio = Screen.width * 1.0f / Screen.height;

        realDevWidth = realDevHeight * 2 * aspectRatio;

        //Debug.Log("realDevWidth = " + realDevWidth);

        if (realDevWidth < devWidth)
        {
            realDevHeight = devWidth / (2 * aspectRatio);
            //Debug.Log("new orthographicSize = " + realDevHeight);
            this.GetComponent<Camera>().orthographicSize = realDevHeight;
        }

        //print("realDevHeight=" + realDevHeight + ",devWidth=" + realDevWidth);

        top = realDevHeight;
        bottom = -top;

        left = devWidth / 2;
        right = -left;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
