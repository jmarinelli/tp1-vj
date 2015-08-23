﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Snake : MonoBehaviour {

	Vector2 dir = Vector2.right;
	List<Transform> tail = new List<Transform>();
	bool ate = false;

	public GameObject tailPrefab;

	void Start () {
		InvokeRepeating("Move", 0.1f, 0.1f);    
	}
	
	void Update() {
	
		if (Input.GetKey(KeyCode.RightArrow))
			dir = Vector2.right;
		else if (Input.GetKey(KeyCode.DownArrow))
			dir = -Vector2.up;  
		else if (Input.GetKey(KeyCode.LeftArrow))
			dir = -Vector2.right;
		else if (Input.GetKey(KeyCode.UpArrow))
			dir = Vector2.up;
	}
	
	void Move() {
		Vector2 v = transform.position;

		transform.Translate(dir);

		

		if (ate) {
		
			GameObject g =(GameObject)Instantiate(tailPrefab, v,Quaternion.identity);


			tail.Insert(0, g.transform);
			

			ate = false;
		}

		else if (tail.Count > 0) {
		
			tail.Last().position = v;
		
			tail.Insert(0, tail.Last());
			tail.RemoveAt(tail.Count-1);
		}
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.name.StartsWith ("borderBottom")) {
			transform.Rotate (new Vector2 (-180, 0));
		} else if (coll.name.StartsWith ("borderTop")) {
			transform.Rotate (new Vector2 (180, 0));
		} else if (coll.name.StartsWith ("borderLeft")) {
			transform.Rotate (new Vector2 (0, 180));
		} else if (coll.name.StartsWith ("borderRight")) {
			transform.Rotate (new Vector2 (0, -180));
		}

		if (coll.name.StartsWith("FoodPrefab")) {

			ate = true;
//			Debug.Log("holis");
			

			Destroy(coll.gameObject);
		}

		else {
			// ToDo 'You lose' screen
		}

	}
}