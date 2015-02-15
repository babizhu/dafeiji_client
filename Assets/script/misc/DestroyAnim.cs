using UnityEngine;
using System.Collections;

public class DestroyAnim : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    
    /**
     * 动画播放完毕之后删除自己
     */
    public void destroySelf()
    {
        Destroy(gameObject);
    }
}
