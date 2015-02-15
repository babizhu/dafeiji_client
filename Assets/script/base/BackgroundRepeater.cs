using UnityEngine;
using System.Collections;

public class BackgroundRepeater : MonoBehaviour {

    //GameObject backGround;
    public float speed = 1f;

    //private Transform cameraTransform;
    private float spriteHeight, realDevHeight;
    private Vector3 newPosition;
	
	void Start () {
        GameCamera gc = Camera.main.GetComponent<GameCamera>();
        realDevHeight = gc.realDevHeight;
       
        SpriteRenderer spriteRenderer = renderer as SpriteRenderer;
        spriteHeight = spriteRenderer.sprite.bounds.size.y;
        newPosition = transform.position;

	}
	
	// Update is called once per frame
    void Update()
    {
        newPosition.y -= Time.deltaTime * speed;
        transform.position = newPosition;

        if (transform.position.y < -realDevHeight*2)
        {

            newPosition.y += 3.0f * spriteHeight;
            transform.position = newPosition;
        }
	
	}
}
