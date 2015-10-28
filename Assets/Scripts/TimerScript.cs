using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour {
	public Text timerLabel;
	
	private float time;
	public GameObject main;
	
	void Update() {
		time += Time.deltaTime;
		
		var minutes = time / 60; 
		var seconds = time % 60;
		var fraction = (time * 100) % 100;
		
		timerLabel.text = string.Format ("{0:00} : {1:00} : {2:000}", minutes, seconds, fraction);

		int top = main.GetComponent<PlatformScript> ().time;
		Debug.Log (top);
		if (seconds > top) {
			Application.LoadLevel("Lost");
		}
	}
	
}