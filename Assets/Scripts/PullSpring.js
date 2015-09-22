#pragma strict

var inputButtonName : String = "Pull";
var distance : float = 50;
var speed : float = 2;
var ball : GameObject;
var power : float = 3000;

private var ready : boolean = false;
private var fire : boolean = false;
private var moveCount : float = 0;

function OnCollisionEnter(_other : Collision) {
	if(_other.gameObject.tag == "Ball"){
		ready = true;
		Debug.Log("Ready");
	}
}

function Update () {

	if(Input.GetButton(inputButtonName)){
		if(moveCount < distance){
			transform.Translate(0,0,-speed * Time.deltaTime);
			moveCount += speed * Time.deltaTime;
			fire = true;
		}
	}
	else if(moveCount > 0){
		if(fire && ready){
			ball.transform.TransformDirection(Vector3.forward * 10);
			ball.GetComponent.<Rigidbody>().AddForce(0, 0, moveCount * power);
			fire = false;
			ready = false;
		}
		transform.Translate(0,0,20 * Time.deltaTime);
		moveCount -= 20 * Time.deltaTime;
	}
	
	if(moveCount <= 0){
		fire = false;
		moveCount = 0;
	}
}