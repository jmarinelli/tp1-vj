using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public int score = 0;
	public int lives = 4;
	public Text[] scoreTxts;
	public Text livesTxt;
	public GameObject ball;
	public Vector3 ballSpawnPosition;
	public GameObject gameoverPanel;
	public GameObject indicatorsPanel;
	public Text gameOverMessage;

	// Use this for initialization
	void Start () {
		setScoreText ();
		setLivesText ();
		gameoverPanel.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		setScoreText ();
		setLivesText ();
	}
	
	void setScoreText(){
		foreach(Text scoreText in scoreTxts) {
			scoreText.text = "Puntaje : " + score;
		}
	}

	void setLivesText(){
		livesTxt.text="Vidas : " + lives;
	}

	public void OnLost(){
		lives -=1;

		if (lives <= 0) {
			gameOverMessage.text = "Perdiste!";
			gameoverPanel.SetActive(true);
			indicatorsPanel.SetActive(false);
			StartCoroutine("LoadMenu");
		} else {
			ball.transform.position = ballSpawnPosition;
			ball.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
		}
	}

	public void OnWin() {
		ball.transform.position = ballSpawnPosition;
		ball.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
		gameOverMessage.text = "Ganaste!";
		gameoverPanel.SetActive(true);
		indicatorsPanel.SetActive(false);
		StartCoroutine("LoadMenu");
	}

	public void OnScore(){
		score += 1;
	}

	public IEnumerator LoadMenu() {
		yield return new WaitForSeconds (5.0f);
		Application.LoadLevel ("MainMenu");
	}

}
