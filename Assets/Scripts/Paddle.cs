using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public float force;
	public string key;
	
	void Start () {
		GetComponent<Rigidbody>().maxAngularVelocity = Mathf.Infinity;
	}
	
	void Update () {
		if( Input.GetKey(key)) {
			GetComponent<Rigidbody>().AddTorque(new Vector3(0, force, 0), ForceMode.Acceleration);
		}

	}
}
