using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public LevelManager LM;
	GameLogic gl;

	public float spawn_time = 4;
	public int spawnCount = 0;

	public GameObject Unitpref;
	// Update is called once per frame
	private void Start(){
		gl = FindObjectOfType<GameLogic> ();
	}

	void Update () {
		if (GameManager.Instance.canSpawn) {
			if (spawn_time <= 0) {
				StartCoroutine (SpawnEnemy (spawnCount));
				spawn_time = 4;
				//spawnCount = 1;

			}
			spawn_time -= Time.deltaTime;

		}
	}

	IEnumerator SpawnEnemy(int enemyCount){
		spawnCount++;
		GameManager.Instance.Wave = spawnCount;
		if (spawnCount == 15) {
			GameManager.Instance.EndingMenu ();
		}
		for (int i = 0; i < enemyCount; i++) {
			GameObject temp_unit = Instantiate (Unitpref);
			temp_unit.transform.SetParent (gameObject.transform, false);
			temp_unit.GetComponent<Unit>().selfEnemy = gl.AllEnemies[Random.Range(0,gl.AllEnemies.Count)];
			Vector3 startPos = new Vector3 (GameObject.Find("LevelGroup").GetComponent<LevelManager> ().waypoints [0].transform.position.x,
				GameObject.Find("LevelGroup").GetComponent<LevelManager> ().waypoints [0].transform.position.y);

			temp_unit.transform.position = startPos;
			yield return new WaitForSeconds (.5f);
		}

	}

}
