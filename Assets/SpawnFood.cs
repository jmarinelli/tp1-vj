using UnityEngine;
using System.Collections;

public class SpawnFood : MonoBehaviour {

	public GameObject foodPrefab;

	public Transform borderTop;
	public Transform borderBottom;
	public Transform borderLeft;
	public Transform borderRight;

	void Start () {
		InvokeRepeating("Spawn", 3, 1);
	}
	

	void Spawn() {
		int x = (int)Random.Range(borderLeft.position.x+10,
		                          borderRight.position.x-10);
		

		int y = (int)Random.Range(borderBottom.position.y+10,
		                          borderTop.position.y-10);
		
	
		Instantiate(foodPrefab,
		            new Vector2(x, y),
		            Quaternion.identity);
	}
}
