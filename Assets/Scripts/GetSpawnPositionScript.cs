using UnityEngine;
using System.Collections;

public class GetSpawnPositionScript : MonoBehaviour {

	public Transform spawnPosition;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public Transform getSpawnPosition() {
		return spawnPosition;
	}
}
