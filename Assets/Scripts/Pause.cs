using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

	public bool paused;
	public GameObject pauseMenu;

	// Use this for initialization
	void Start () {
		paused = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
						paused = !paused;
		}
		if(paused){
			Time.timeScale = 0;
			pauseMenu.SetActive(true);
		}else if(!paused){
			Time.timeScale = 1;
			pauseMenu.SetActive(false);
		}

	}
}
