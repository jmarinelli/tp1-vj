
@script AddComponentMenu ("Scripts/Car Control Script")
#pragma strict
var centerOfMass : Vector3;	
var dataWheel : WheelCollider;	
var lowestSteerAtSpeed : float = 50;	
var lowSpeedSteerAngel : float = 10;
var highSpeedSteerAngel : float = 1;	
var decellarationSpeed : float = 5;
var maxTorque : float  = 40;	
var currentSpeed : float;		
var topSpeed : float = 150;		
var maxReverseSpeed : float = 50; 
var backLightObject : GameObject;	
var idleLightMaterial : Material;	
var brakeLightMaterial : Material; 	
var reverseLightMaterial : Material;	
@HideInInspector	
var braked : boolean = false;	
var maxBrakeTorque : float = 80; 
var speedOMeterDial : Texture2D;
var speedOMeterPointer : Texture2D;	
var gearRatio : int[];		
var spark : GameObject;		
var collisionSound : GameObject;

function Start () {
GetComponent.<Rigidbody>().centerOfMass=centerOfMass; 
}

function FixedUpdate () {
HandBrake();
}
function Update(){
BackLight ();
EngineSound();
CalculateSpeed();
}



function CalculateSpeed(){
currentSpeed = 2*22/7*dataWheel.radius*dataWheel.rpm*60/1000;
currentSpeed = Mathf.Round(currentSpeed);
}



function BackLight (){
if (currentSpeed > 0 && Input.GetAxis("Vertical")<0&&!braked){
backLightObject.GetComponent.<Renderer>().material = brakeLightMaterial;
}
else if (currentSpeed < 0 && Input.GetAxis("Vertical")>0&&!braked){
backLightObject.GetComponent.<Renderer>().material = brakeLightMaterial;
}
else if (currentSpeed < 0 && Input.GetAxis("Vertical")<0&&!braked){
backLightObject.GetComponent.<Renderer>().material = reverseLightMaterial;
}
else if (!braked){
backLightObject.GetComponent.<Renderer>().material = idleLightMaterial;
}
}


function HandBrake(){
if (Input.GetButton("Jump")){
braked = true;
}
else{
braked = false;
}
}


function EngineSound(){
for (var i = 0; i < gearRatio.length; i++){
if(gearRatio[i]> currentSpeed){
break;
}
}
var gearMinValue : float = 0.00;
var gearMaxValue : float = 0.00;
if (i == 0){
gearMinValue = 0;
}
else {
gearMinValue = gearRatio[i-1];
}
gearMaxValue = gearRatio[i];
var enginePitch : float = ((currentSpeed - gearMinValue)/(gearMaxValue - gearMinValue))+1;
GetComponent.<AudioSource>().pitch = enginePitch;
}


function OnGUI (){
GUI.DrawTexture(Rect(Screen.width - 300,Screen.height - 150,300,150),speedOMeterDial);
var speedFactor : float = currentSpeed / topSpeed;
var rotationAngle : float;
if (currentSpeed >= 0){
  rotationAngle = Mathf.Lerp(0,180,speedFactor);
  }
  else {
  rotationAngle = Mathf.Lerp(0,180,-speedFactor);
  }
GUIUtility.RotateAroundPivot(rotationAngle,Vector2(Screen.width - 150 ,Screen.height));
GUI.DrawTexture(Rect(Screen.width - 300,Screen.height - 150,300,300),speedOMeterPointer);

}


function OnDrawGizmos  () {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere (transform.position+centerOfMass, 0.1);
    }
