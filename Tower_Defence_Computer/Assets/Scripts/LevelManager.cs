using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelManager : MonoBehaviour {
	public int field_width, field_height;
	public GameObject CellPref;
	public Transform CellParent;
	public int q = 7;
	public Sprite[] tiles = new Sprite[2];

	public List<GameObject> waypoints = new List<GameObject>();
	GameObject[,] allCells = new GameObject[17,31];
	int currWayX, currWayY;
	GameObject first_Cell;
	// Use this for initialization
	void Start () {
		//LoadLevel (1);
		CreateLevel ();
		//LoadWaypoints ();
	}

	public void CreateLevel()
	{
		waypoints.Clear();
		first_Cell = null;

		Vector3 worldVec = Camera.main.ScreenToWorldPoint(new Vector3(0,Screen.height,0));
		for(int i = 0; i < field_height; i++)
			for(int j = 0; j < field_width; j++){
				int sprIndex = int.Parse (LoadLevel(1)[i].ToCharArray () [j].ToString ());
				//int sprIndex = int.Parse (path[i].ToCharArray () [j].ToString ());

				Sprite spr = tiles[sprIndex];

				bool isGround = spr == tiles [1] ? true : false;
				//Debug.Log (isGround);
				CreateCell(isGround,spr,j,i,worldVec);

			}

		LoadWaypoints();

	}
	void CreateCell (bool isGround, Sprite spr,int x, int y, Vector3 wv) {
		GameObject temp_Cell = Instantiate (CellPref);
		temp_Cell.transform.SetParent (CellParent,false);
		temp_Cell.GetComponent<SpriteRenderer>().sprite = spr;
		float spriteSizeX = temp_Cell.GetComponent<SpriteRenderer> ().bounds.size.x;
		float spriteSizeY = temp_Cell.GetComponent<SpriteRenderer> ().bounds.size.y;
		temp_Cell.transform.position = new Vector3(wv.x + (spriteSizeX*x),wv.y +(spriteSizeY*-y));
		if (isGround) {
			//Debug.Log ("gotcha");
			temp_Cell.GetComponent<Cell>().isGround = true;
			if (first_Cell == null) {
				first_Cell = temp_Cell;
				currWayX = x;
				currWayY = y;
			}
			//Debug.Log (currWayX);
			//Debug.Log (currWayY);
		}
		allCells [y, x] = temp_Cell;
	}

	string[] LoadLevel(int i){
		TextAsset temp_text = (TextAsset) Resources.Load ("Level" + i +"Ground", typeof (TextAsset));
		string temp_string = temp_text.text.Replace (Environment.NewLine, string.Empty);
		return temp_string.Split ('!');
	}
	void LoadWaypoints(){
		GameObject currWayTo;
		waypoints.Add (first_Cell);

		//Debug.Log (first_Cell);
		//Debug.Log (waypoints);

		while (true) {
			currWayTo = null;
			if (currWayX > 0 && allCells [currWayY, currWayX - 1].GetComponent<Cell> ().isGround &&
				!waypoints.Exists (x => x == allCells [currWayY, currWayX - 1])) {
				currWayTo = allCells [currWayY, currWayX - 1];
				currWayX--;
				//Debug.Log ("To left");
			}
			else if (currWayX < (field_width - 1) && allCells [currWayY, currWayX + 1].GetComponent<Cell> ().isGround && 
				!waypoints.Exists (x => x == allCells [currWayY, currWayX + 1])) {
				currWayTo = allCells [currWayY, currWayX + 1];
				currWayX++;
				//Debug.Log ("To right");
			}
			else if (currWayY > 0 && allCells [currWayY - 1, currWayX].GetComponent<Cell> ().isGround && 
				!waypoints.Exists (x => x == allCells [currWayY - 1, currWayX])) {
				currWayTo = allCells [currWayY - 1, currWayX];
				currWayY--;
				//Debug.Log ("To up");
			}
			else if (currWayY < (field_height - 1) && allCells [currWayY + 1, currWayX].GetComponent<Cell> ().isGround && 
				!waypoints.Exists (x => x == allCells [currWayY + 1, currWayX])) {
				currWayTo = allCells [currWayY + 1, currWayX];
				currWayY++;
				//Debug.Log ("To down");
			} else
				break;
			waypoints.Add (currWayTo);
		}
	}
}
