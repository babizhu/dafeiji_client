using UnityEngine;
using System.Collections;

public class SceneBase : MonoBehaviour {

	// Use this for initialization
    
	void Start () {
        buildBackground();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void buildBackground()
    {
        int bgId = Random.Range(1, 4);
        Instantiate(Resources.Load("background/bg" + bgId));
	}
    
}
