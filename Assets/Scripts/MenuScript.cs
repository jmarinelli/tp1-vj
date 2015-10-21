using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {
	public InputField chunksInput;
	public Dropdown difficultyInput;


	public static int size;
	public static int difficulty;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void QuitGame(){
		Application.Quit();
	}

	public void StartGame(){
		size = int.Parse (chunksInput.text);
		difficulty = difficultyInput.value;
		Application.LoadLevel ("Main");
	}

}
