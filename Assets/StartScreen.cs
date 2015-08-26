using UnityEngine;
using System.Collections;

public class StartScreen : MonoBehaviour {

	public void playEvent() {
		Application.LoadLevel("Scene1");
	}

	public void quitEvent() {
		Application.Quit ();
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
