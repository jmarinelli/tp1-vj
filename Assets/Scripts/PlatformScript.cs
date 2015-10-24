using UnityEngine;
using System.Collections;

public class PlatformScript : MonoBehaviour {

	public int length;
	public int size;
	public GameObject[] chunks;
	
	public void Start() {
		GameObject[,] matrix = new GameObject[size, size];
		int iCol = Random.Range (1, size - 1);
		int iRow = Random.Range (1, size - 1);
		GameObject initialChunk = chunks [Random.Range (0, chunks.Length - 1)];
		matrix[iRow, iCol] = initialChunk;
		fillChunks(matrix, initialChunk, iRow, iCol, iRow, iCol, length, 1);
		print ("\n-------- YEEEEEEEY ----------\n");
		PrintMatrix (matrix);
	}

	public bool fillChunks(GameObject[,] matrix, GameObject iChunk, int iRow, int iCol, int row, int col, int L, int n) {
		if(n > size * size) {
			return false;
		}
		GameObject lastChunk = matrix [row, col];
		int nRow = lastChunk.GetComponent<ChunkScript> ().endPointRow + row;
		int nCol = lastChunk.GetComponent<ChunkScript> ().endPointCol + col;
		if (nRow < 0 || nRow >= size || nCol < 0 || nCol >= size) {
				// Choque contra pared
			print ("hit wall with " + lastChunk.GetComponent<ChunkScript>().label);
			return false;
		} else if (matrix[nRow, nCol] != null) {
			// Choque con alguna pistita
			GameObject existentChunk = matrix[nRow, nCol];
			if (existentChunk == iChunk && L <= n && Contains(lastChunk.GetComponent<ChunkScript>().connectedChunks, existentChunk)) {
				// Choque con la inicial y justo lo cerré
				return true;
			} else {
				print ("hit chunk with " + lastChunk.GetComponent<ChunkScript>().label);
				return false;
			}
		}

		int closeRow = iChunk.GetComponent<ChunkScript>().startPointRow + iRow;
		int closeCol = iChunk.GetComponent<ChunkScript>().startPointCol + iCol;
		if (row == closeRow && col == closeCol) {
			return false;
		}

		PrintMatrix (matrix);
		
		foreach(GameObject chunk in lastChunk.GetComponent<ChunkScript>().connectedChunks) {
			matrix[nRow, nCol] = chunk;
			if(fillChunks(matrix, iChunk, iRow, iCol, nRow, nCol, L, n+1)) {
				return true;
			}
		}
		matrix [nRow, nCol] = null;
		return false;
	}

	private bool Contains(GameObject[] objects, GameObject o) {
		foreach(GameObject i in objects) {
			if( i.GetComponent<ChunkScript>().label.Equals(o.GetComponent<ChunkScript>().label)) return true;
		}
		print ("doesnt contain " + o.GetComponent<ChunkScript>().label);
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
}
