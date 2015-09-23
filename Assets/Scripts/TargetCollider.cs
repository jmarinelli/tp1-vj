using UnityEngine;
using System.Collections;

public class TargetCollider : MonoBehaviour {

	public GameController gameController;

	void OnTriggerEnter(Collider col) {
		Debug.Log ("Win");
		gameController.OnWin ();
	}
}
