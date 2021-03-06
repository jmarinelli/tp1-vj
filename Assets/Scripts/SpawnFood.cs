﻿using UnityEngine;
using System.Collections;

public class SpawnFood : MonoBehaviour {

	public GameObject foodPrefab;
	public GameObject applePrefab;
	public GameObject snitch;
	GameObject clonesnitch;


	public Transform borderTop;
	public Transform borderBottom;
	public Transform borderLeft;
	public Transform borderRight;

	void Start () {
		InvokeRepeating("Spawn", 4, 7);
		InvokeRepeating("SpawnApples", 1, 2);
		InvokeRepeating("SpawnSnitch", 5, 6);
		InvokeRepeating("DestroySnitch", 6, 7);
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

	void SpawnApples() {
		int x = (int)Random.Range(borderLeft.position.x+10,
		                          borderRight.position.x-10);
		
		
		int y = (int)Random.Range(borderBottom.position.y+10,
		                          borderTop.position.y-10);
		
		
		Instantiate(applePrefab,
		            new Vector2(x, y),
		            Quaternion.identity);
		
	}

	void SpawnSnitch() {
		int x = (int)Random.Range(borderLeft.position.x+10,
		                          borderRight.position.x-10);
		
		
		int y = (int)Random.Range(borderBottom.position.y+10,
		                          borderTop.position.y-10);
		
		
		clonesnitch = (GameObject)Instantiate(snitch,
		            new Vector2(x, y),
		            Quaternion.identity);
		
	}

	void DestroySnitch(){
		Destroy(clonesnitch);
	}
}
