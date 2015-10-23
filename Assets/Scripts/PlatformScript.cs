using UnityEngine;
using System.Collections;

public class PlatformScript : MonoBehaviour {

	
	public GameObject[] platforms;

	public int size;

	public int difficulty;

	private GameObject lastPlatform;
	
	public Transform spawnPosition;


	void Start () {
		//size = MenuScript.size;
		difficulty = MenuScript.difficulty;

		Debug.Log (size);
		GameObject[] halfTrack = new GameObject[size];
		for (int i = 0; i < size; i++) {
			GameObject platform = platforms [Random.Range (0, platforms.Length)];
			GameObject newPlatform = InstantiatePlatform (platform);
			halfTrack[i] = newPlatform;

		}

//		GameObject bridge1 = new GameObject[20];
//		for (int i = 0; i < 20; i++) {
//			GameObject platform = platforms[0];
//			GameObject newPlatform = InstantiatePlatform (platform);
//			halfTrack[i] = newPlatform;
//		}
//		GameObject bridge2 = new GameObject[20];

		GameObject platform2 = halfTrack[size-1];
		GameObject pepe2 = InstantiatePlatform (platform2);
		pepe2.transform.Rotate(new Vector3(0,180,0));
		pepe2.transform.position = new Vector3(pepe2.transform.position.x + 20, pepe2.transform.position.y, pepe2.transform.position.z);

		for (int i = size-2; i > 0; i--) {
			InstantiatePlatform (platform2);
			platform2 = halfTrack[i];
		}
	}
	
	void Update () {
	
	}

	public GameObject InstantiatePlatform(GameObject platform) {

		lastPlatform = (GameObject) Instantiate(platform,  new Vector3(spawnPosition.position.x, spawnPosition.position.y, spawnPosition.position.z), spawnPosition.rotation);
		spawnPosition = lastPlatform.GetComponent<GetSpawnPositionScript>().getSpawnPosition();
		return lastPlatform;
	}
}
