using UnityEngine;
using System.Collections;

public class PlatformScript : MonoBehaviour {

	public int length;
	public int size;
	public GameObject[] chunks;
	public Transform spawnPoint;
	public int maxIterations;
	public GameObject car;
	
	public void Start() {

//		if (MenuScript.size == 0) {
//			size = 3;
//			if(MenuScript.difficulty == 0){
//				length = 3;
//			} else if(MenuScript.difficulty == 1){
//				length = 5;
//			} else {
//				length =8;
//			}
//			Debug.Log("Size "+ size + " length " + length);
//		} else if (MenuScript.size == 1) {
//			size = 6;
//			if(MenuScript.difficulty == 0){
//				length = 8;
//			} else if(MenuScript.difficulty == 1){
//				length = 10;
//			} else {
//				length =15;
//			}
//			Debug.Log("Size " + size + " length " + length);
//		} else {
//			size = 10;
//			if(MenuScript.difficulty == 0){
//				length = 3;
//			} else if(MenuScript.difficulty == 1){
//				length = 45;
//			} else {
//				length =50;
//			}
//			Debug.Log("Size " + size + " length " + length);
//		}

		GameObject[,] matrix = new GameObject[size, size];
		int iCol = Random.Range (1, size - 1);
		int iRow = Random.Range (1, size - 1);
		GameObject initialChunk = chunks [Random.Range (0, chunks.Length - 1)];
//		GameObject initialChunk = chunks [0];
		matrix[iRow, iCol] = initialChunk;
		fillChunks(matrix, initialChunk, iRow, iCol, iRow, iCol, length, 1);
		Debug.Log (initialChunk.transform.position.x);
		Debug.Log (initialChunk.transform.position.z);
		print ("\n-------- YEEEEEEEY ----------\n");
//		PrintMatrix (matrix);
		InstantiateChunks (matrix);
		car.transform.position = new Vector3 (iCol * 15, car.transform.position.y, -iRow * 15);
		car.transform.rotation = Quaternion.AngleAxis (initialChunk.GetComponent<ChunkScript> ().carRotation, Vector3.up);

	}

	public bool fillChunks(GameObject[,] matrix, GameObject iChunk, int iRow, int iCol, int row, int col, int L, int n) {
		GameObject lastChunk = matrix [row, col];
		int nRow = lastChunk.GetComponent<ChunkScript> ().endPointRow + row;
		int nCol = lastChunk.GetComponent<ChunkScript> ().endPointCol + col;
		if (nRow < 0 || nRow >= size || nCol < 0 || nCol >= size) {
				// Choque contra pared
//			print ("hit wall with " + lastChunk.GetComponent<ChunkScript>().label);
			return false;
		} else if (matrix[nRow, nCol] != null) {
			// Choque con alguna pistita
			GameObject existentChunk = matrix[nRow, nCol];
			if (existentChunk == iChunk && L <= n && Contains(lastChunk.GetComponent<ChunkScript>().connectedChunks, existentChunk)) {
				// Choque con la inicial y justo lo cerré
				return true;
			} else {
//				print ("hit chunk with " + lastChunk.GetComponent<ChunkScript>().label);
				return false;
			}
		}

		int closeRow = iChunk.GetComponent<ChunkScript>().startPointRow + iRow;
		int closeCol = iChunk.GetComponent<ChunkScript>().startPointCol + iCol;
		if (row == closeRow && col == closeCol) {
//			Debug.Log ("Closed End");
			return false;
		}

//		PrintMatrix (matrix);
		
		foreach(GameObject chunk in lastChunk.GetComponent<ChunkScript>().connectedChunks) {
			matrix[nRow, nCol] = chunk;
			if (maxIterations-- < 0) {
				print ("max it " + iRow + " " + iCol);
				matrix [nRow, nCol] = null;
				return false;
			}
			if(fillChunks(matrix, iChunk, iRow, iCol, nRow, nCol, L, n+1)) {
				return true;
			}
		}
		matrix [nRow, nCol] = null;
		return false;
	}

	private bool Contains(GameObject[] objects, GameObject o) {
//		print ("contains " + o.GetComponent<ChunkScript>().label + "/n");
		foreach(GameObject i in objects) {
//			print ("object " + i.GetComponent<ChunkScript>().label + "n"	);
			if( i.GetComponent<ChunkScript>().label.Equals(o.GetComponent<ChunkScript>().label)){ 
				return true;
			}
		}
//		print ("doesnt contain " + o.GetComponent<ChunkScript>().label);
		return false;
	}

	private void PrintMatrix(GameObject[,] matrix) {
		for (int r =0; r < matrix.GetLength(0); r++) {
			string rowString = "|";
			for(int c = 0; c < matrix.GetLength(1); c++) {
				GameObject chunk = matrix[r,c];
				if(chunk != null) {
					rowString += " " + chunk.GetComponent<ChunkScript>().label;
				} else {
					rowString += " --";
				}
			}
			rowString += "|";
			print(rowString);
		}
		print ("\n");
	}

	private void InstantiateChunks(GameObject[,] matrix) {
		for (int r =0; r < matrix.GetLength(0); r++) {
			string rowString = "|";
			for(int c = 0; c < matrix.GetLength(1); c++) {
				GameObject chunk = matrix[r,c];
				if(chunk != null) {
					Vector3 position = new Vector3(spawnPoint.position.x + c * 15, 0, spawnPoint.position.z - r * 15);
					Instantiate(chunk, position, Quaternion.identity);
				}
			}
		}
	}
}
