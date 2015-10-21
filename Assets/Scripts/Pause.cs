using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

	public bool paused;
	public GameObject pauseMenu;

	void Start () {
		paused = false;
	}
	
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
