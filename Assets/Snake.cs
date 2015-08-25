using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Snake : MonoBehaviour {

	private Vector2 dir = Vector2.right;
	private List<Transform> tail = new List<Transform>();
	private bool ate = false;
	public static int score = 0;


	public Transform bottom, top, right, left;
	public GameObject tailPrefab;

	void Start () {
		InvokeRepeating("Move", 0.025f, 0.025f);    
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
			score += 1;
			GameObject g =(GameObject)Instantiate(tailPrefab, v,Quaternion.identity);

			tail.Insert(0, g.transform);
			ate = false;
		} else if (tail.Count > 0) {
			tail.Last().position = v;
			tail.Insert(0, tail.Last());
			tail.RemoveAt(tail.Count-1);
		}
	}

	void OnCollisionExit2D(Collision2D collision) {
		if (collision.transform.position.Equals(transform.position)) {
			Debug.Log ("giladita");
		}
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.name.StartsWith ("borderBottom")) {
			transform.position = new Vector3(transform.position.x, top.position.y - 1, 0);
		} else if (coll.name.StartsWith ("borderTop")) {
			transform.position = new Vector3(transform.position.x, bottom.position.y + 1, 0);
		} else if (coll.name.StartsWith ("borderLeft")) {
			transform.position = new Vector3(right.position.x - 1, transform.position.y, 0);
		} else if (coll.name.StartsWith ("borderRight")) {
			transform.position = new Vector3(left.position.x + 1, transform.position.y, 0);
		}

		if (coll.name.StartsWith("FoodPrefab")) {
			ate = true;
			Destroy(coll.gameObject);
		}

	}
}