using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public GameController gameController;

	void OnCollisionEnter(Collision col) {
		gameController.OnScore();
	}
}
