using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Towersrc : MonoBehaviour {

	public GameObject Projectile;
	GameLogic gl;
	public Tower selftower;
	public TypeTower selftype;

	private void Start(){

		gl = FindObjectOfType<GameLogic>();

		selftower = gl.AllTowers[(int)selftype];
		GetComponent<SpriteRenderer> ().sprite = selftower.Spr;
		InvokeRepeating ("SearchforTarget",0, .1f);
	}
	void Update(){
		

		if (selftower.currCooldown > 0) {
			selftower.currCooldown -= Time.deltaTime;
		}
	}

	bool CanShoot(){
		if (selftower.currCooldown <= 0) {
			return true;
		}
		return false;	

	}
	void SearchforTarget(){
		if (CanShoot()) {
			Transform nearestUnit = null;
			float nearestUnitdistance = Mathf.Infinity;
			foreach (GameObject unit in GameObject.FindGameObjectsWithTag("Unit")) {
				float currDistance = Vector2.Distance (transform.position, unit.transform.position);
				if (currDistance <= selftower.range && currDistance <= nearestUnitdistance) {
					nearestUnit = unit.transform;
					nearestUnitdistance = currDistance;
				}

			}
			if (nearestUnit != null) {
				Shoot (nearestUnit);
			}
		}
	}
	void Shoot(Transform unit){
		selftower.currCooldown = selftower.Cooldown;
		GameObject proj = Instantiate (Projectile);
		Vector3 startPos = new Vector3 (transform.position.x +GetComponent<SpriteRenderer>().bounds.size.x/2,
			transform.position.y );
		proj.GetComponent<TowerProject> ().selfTower = selftower;
		proj.transform.position = startPos;
		proj.GetComponent<TowerProject> ().setTarget (unit);
	}
}
