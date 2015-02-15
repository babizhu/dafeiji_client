using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

    public Sprite[] numSprites;

    private SpriteRenderer ge;
    private SpriteRenderer shi;
    private SpriteRenderer bai;
    private SpriteRenderer qian;

    public static int number = 0;
	// Use this for initialization
	void Start () {
		//transform.Find("b0").gameObject.GetComponent<Score>();
		ge = getScoreObj("ge");
		shi = getScoreObj("shi");
		bai = getScoreObj("bai");
		qian = getScoreObj("qian");

        //setNumber(1984);
		//setNumber(0);
		//ge.SetNumber( 4) ;
	}
	
	// Update is called once per frame
	void Update () {
	}

	private void setNumber( int number ){
        ge.sprite = numSprites[number % 10];
        shi.sprite = numSprites[number % 100 / 10];
        bai.sprite = numSprites[number % 1000 / 100];
        qian.sprite = numSprites[number / 1000];
        
	}

    public void addNumber(int addValue)
    {
        number += addValue;
        setNumber(number);
    }
	

    private SpriteRenderer getScoreObj(string name)
    {
		foreach( Transform t in gameObject.GetComponentsInChildren<Transform>() ){
			if( t.name == name ){
                return t.GetComponent<SpriteRenderer>();
			}
		}
			return null;
	}
}
