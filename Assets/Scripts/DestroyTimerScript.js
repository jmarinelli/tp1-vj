

@script AddComponentMenu ("/Destroy Timer Script")
#pragma strict
var destroyAfter : float = 7; 	
private var timer : float; 	


function Update () {
timer += Time.deltaTime;
if (destroyAfter <= timer){
Destroy(gameObject);
}
}