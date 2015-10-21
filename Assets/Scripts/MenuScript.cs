using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

	public GameObject chunksInput;
	public GameObject difficultyInput;

	public static GameObject chunks;
	public static GameObject difficulty;

	// Use this for initialization
	void Start () {
		chunks = chunksInput;
		difficulty = difficultyInput;	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void QuitGame(){
		Application.Quit();
	}

	public void StartGame(){
		Application.LoadLevel ("Main");

	}

}
