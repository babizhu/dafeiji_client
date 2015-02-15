using UnityEngine;
using System.Collections;

public class GameCamera : MonoBehaviour {

    public float realDevHeight, realDevWidth;
    float devHeight = 9.6f;
     float devWidth = 6.4f;
	// Use this for initialization
	void Awake () {
	float screenHeight = Screen.height;

        //Debug.Log ("screenHeight = " + screenHeight);

        //this.GetComponent<Camera>().orthographicSize = screenHeight / 200.0f;

        realDevHeight = this.GetComponent<Camera>().orthographicSize;

        float aspectRatio = Screen.width * 1.0f / Screen.height;

        realDevWidth = realDevHeight * 2 * aspectRatio;

        //Debug.Log("realDevWidth = " + realDevWidth);

        if (realDevWidth < devWidth)
        {
            realDevHeight = devWidth / (2 * aspectRatio);
            Debug.Log("new orthographicSize = " + realDevHeight);
            this.GetComponent<Camera>().orthographicSize = realDevHeight;
        }

        //print("realDevHeight=" + realDevHeight + ",devWidth=" + realDevWidth);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
