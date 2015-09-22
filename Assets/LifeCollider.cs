using UnityEngine;
using System.Collections;

public class LifeCollider : MonoBehaviour {

	public GameController gameController;

	void OnTriggerEnter(Collider col) {
		Debug.Log ("COLLIDED");
		gameController.OnLost ();
	}
}
