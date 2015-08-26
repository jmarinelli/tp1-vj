using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class EndGame : MonoBehaviour {

	public Text txt;

	public void restart() {
		Application.LoadLevel ("StartScreen");
	}

	void Start () {
		txt.text = txt.text + Snake.instance.score;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
