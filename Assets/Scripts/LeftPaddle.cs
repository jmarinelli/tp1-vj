using UnityEngine;
using System.Collections;

public class LeftPaddle : MonoBehaviour {

	public float force;
	
	void Start () {
	
	}

	void Update () {
				if (Input.GetKey ("left")) {
						GetComponent<Rigidbody> ().AddTorque (new Vector3 (0, force, 0), ForceMode.Impulse);
				}
		}
}