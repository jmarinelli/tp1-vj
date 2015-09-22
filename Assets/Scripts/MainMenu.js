#pragma strict

function QuitGame(){
	Debug.Log("exit game");
	Application.Quit();
}

function StartGame(){
	Application.LoadLevel("GameScene");
}
