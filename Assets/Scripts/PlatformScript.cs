using UnityEngine;
using System.Collections;

public class PlatformScript : MonoBehaviour {

	
	//object prefab for clone
	public GameObject[] platforms;

	public int size;

	public int difficulty;

	//this is automatic access do not change
	private GameObject lastPlatform;
	
	public Transform spawnPosition;


	// Use this for initialization
	void Start () {
		//meter en for
		size = MenuScript.size;
		difficulty = MenuScript.difficulty;

		for (int i = 0; i < size; i++) {
			GameObject platform = platforms [Random.Range (0, platforms.Length)];
			InstantiatePlatform (platform);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void InstantiatePlatform(GameObject platform) {

		lastPlatform = (GameObject) Instantiate(platform,  new Vector3(spawnPosition.position.x, spawnPosition.position.y, spawnPosition.position.z), spawnPosition.rotation);
		spawnPosition = lastPlatform.GetComponent<GetSpawnPositionScript>().getSpawnPosition();
	}
}
