using UnityEngine;
using System.Collections;

public class PlatformScript : MonoBehaviour {

	
	//object prefab for clone
	public GameObject[] platforms;

	//this is automatic access do not change
	private GameObject lastPlatform;
	
	public Transform spawnPosition;


	// Use this for initialization
	void Start () {
		//Instantiate on start
		InstantiatePlatform(platforms);
		InstantiatePlatform(platforms);
		InstantiatePlatform(platforms);
		InstantiatePlatform(platforms);
		InstantiatePlatform(platforms);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void InstantiatePlatform(GameObject[] platforms) {
		GameObject platform = platforms [Random.Range (0, platforms.Length)];
		lastPlatform = (GameObject) Instantiate(platform,  new Vector3(spawnPosition.position.x, spawnPosition.position.y, spawnPosition.position.z), spawnPosition.rotation);
		spawnPosition = lastPlatform.GetComponent<GetSpawnPositionScript>().getSpawnPosition();
	}
}
