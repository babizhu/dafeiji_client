using UnityEngine;
using System.Collections;

public class Lose : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject.Find("score").GetComponent<GUIText>().text = "得分 " + ScoreManager.number;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            //print("AbstractMonster.count" + AbstractMonster.MONSTER_COUNT);
            //AbstractMonster.MONSTER_COUNT = 0;
            Application.LoadLevel("main");
            
            ScoreManager.number = 0;
        }
	}
}
