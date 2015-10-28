

@script AddComponentMenu ("/Wheel Script")
#pragma strict
enum wheelType { Steer , SteerAndMotor , Motor , JustAWheel}; 
var typeOfWheel : wheelType;	
var handBreakable : boolean = false;	
var invertSteer : boolean = false;	
var wheelTransform : Transform;		
private var speedFactor : float;	
private var wheelCollider : WheelCollider;	
private var carScript : CarControleScript;	
private var mySidewayFriction : float;	
private var myForwardFriction : float;	
private var slipSidewayFriction : float;	
private var slipForwardFriction : float;




function Start () {
wheelCollider = gameObject.GetComponent(WheelCollider);
carScript = transform.root.gameObject.GetComponent("CarControleScript");
SetValues();
}

function SetValues(){

myForwardFriction  = wheelCollider.forwardFriction.stiffness;
mySidewayFriction  = wheelCollider.sidewaysFriction.stiffness;
slipForwardFriction = 0.05;
slipSidewayFriction = 0.085;

}


function Update () {
WheelPosition();
ReverseSlip();
//Rotation Control
wheelTransform.Rotate(wheelCollider.rpm/60*360*Time.deltaTime,0,0);
if (typeOfWheel == wheelType.Steer || typeOfWheel == wheelType.SteerAndMotor)
wheelTransform.localEulerAngles.y = wheelCollider.steerAngle - wheelTransform.localEulerAngles.z;

}



function FixedUpdate (){
if (typeOfWheel == wheelType.Motor || typeOfWheel == wheelType.SteerAndMotor){
TorqueControle ();
}
if (typeOfWheel == wheelType.Steer || typeOfWheel == wheelType.SteerAndMotor){
SteerControle ();
}
if (handBreakable){
HandBrake();
}
if(!carScript.braked){
Decellaration();
}
}


function WheelPosition(){
var hit : RaycastHit;
var wheelPos : Vector3;

if (Physics.Raycast(transform.position, -transform.up,hit,wheelCollider.radius+wheelCollider.suspensionDistance) ){
wheelPos = hit.point+transform.up * wheelCollider.radius;
}
else {
wheelPos = transform.position -transform.up* wheelCollider.suspensionDistance; 
}
wheelTransform.position = wheelPos;
}



function Decellaration(){
if (Input.GetButton("Vertical")==false){
wheelCollider.brakeTorque = carScript.decellarationSpeed;
}
else{
wheelCollider.brakeTorque = 0;
}
}


function SteerControle (){
speedFactor = transform.parent.root.GetComponent.<Rigidbody>().velocity.magnitude/carScript.lowestSteerAtSpeed;
var currentSteerAngel = Mathf.Lerp(carScript.lowSpeedSteerAngel,carScript.highSpeedSteerAngel,speedFactor);
if (invertSteer)
currentSteerAngel *= -Input.GetAxis("Horizontal");
else 
currentSteerAngel *= Input.GetAxis("Horizontal");
wheelCollider.steerAngle = currentSteerAngel;
}




function TorqueControle (){
if (carScript.currentSpeed < carScript.topSpeed && carScript.currentSpeed > -carScript.maxReverseSpeed && !carScript.braked){
wheelCollider.motorTorque = carScript.maxTorque * Input.GetAxis("Vertical");
}
else {
wheelCollider.motorTorque =0;
}
}


function HandBrake(){
if (carScript.braked){
if (carScript.currentSpeed > 1){
SetRearSlip(slipForwardFriction ,slipSidewayFriction); 
}
else if (carScript.currentSpeed < 0){
SetRearSlip(1 ,1); 
}
wheelCollider.brakeTorque = carScript.maxBrakeTorque;
wheelCollider.motorTorque =0;
if (carScript.currentSpeed < 1 && carScript.currentSpeed > -1){
carScript.backLightObject.GetComponent.<Renderer>().material = carScript.idleLightMaterial;
}
else {
carScript.backLightObject.GetComponent.<Renderer>().material = carScript.brakeLightMaterial;
}
}
else {
wheelCollider.brakeTorque = 0;
SetRearSlip(myForwardFriction ,mySidewayFriction); 
}
}



function ReverseSlip(){
if (carScript.currentSpeed <0){
SetFrontSlip(slipForwardFriction ,slipSidewayFriction); 
}
else {
SetFrontSlip(myForwardFriction ,mySidewayFriction);
}
}



function SetRearSlip (currentForwardFriction : float,currentSidewayFriction : float){
if (typeOfWheel == wheelType.Motor || typeOfWheel == wheelType.SteerAndMotor && !carScript.braked){
wheelCollider.forwardFriction.stiffness = currentForwardFriction;
wheelCollider.sidewaysFriction.stiffness = currentSidewayFriction;
}
}
function SetFrontSlip (currentForwardFriction : float,currentSidewayFriction : float){
if (typeOfWheel == wheelType.Steer || typeOfWheel == wheelType.SteerAndMotor && !carScript.braked){
wheelCollider.forwardFriction.stiffness = currentForwardFriction;
wheelCollider.sidewaysFriction.stiffness = currentSidewayFriction;
}
}