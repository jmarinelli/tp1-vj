using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {
	
	Text txt;
	public int score;

	void Start () {
		txt = gameObject.GetComponent<Text>(); 
		txt.text="Score : " + Snake.score;
	}

	void Update () {
		txt.text="Score : " + Snake.score;  
	
	}
}