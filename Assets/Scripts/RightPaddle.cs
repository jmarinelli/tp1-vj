using UnityEngine;
using System.Collections;

public class RightPaddle : MonoBehaviour {

	public float force;
	
	void Start () {
	
	}
	
	void Update () {
		if( Input.GetKey("right")) {
			GetComponent<Rigidbody>().AddTorque(new Vector3(0, force, 0), ForceMode.Impulse);
		}

	}
}
