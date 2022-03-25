using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerProject : MonoBehaviour {
	Transform target;
	Towerprojectile selfProlectile;
	public Tower selfTower;
	GameLogic gl;
	// Use this for initialization
	void Start () {
		
		gl = FindObjectOfType<GameLogic>();
		selfProlectile = gl.Allprojectiles [selfTower.type];
		GetComponent<SpriteRenderer> ().sprite = selfProlectile.Spr;
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
	}
	public void setTarget(Transform unit){
		target = unit;
	}
	private void Move(){
		if (target != null) {
			if (Vector2.Distance (transform.position, target.position) < 1f) {
				Hit ();
			} else {
				Vector2 dir = target.position - transform.position;
				transform.Translate (dir.normalized * Time.deltaTime * selfProlectile.speed, Space.World);
			}
		} else {
			Destroy (gameObject);
		}
	}
	void Hit(){
		switch (selfTower.type) {
		case(int)TypeTower.Fire:
			target.GetComponent<Unit> ().ElementalDamage(selfProlectile.damage);
			break;
		case(int)TypeTower.Water:
			target.GetComponent<Unit> ().StartSlow (3,2);
			target.GetComponent<Unit> ().ElementalDamage(selfProlectile.damage);

			break;
		case(int)TypeTower.Earth:
			target.GetComponent<Unit> ().AOEplzWork (60, selfProlectile.damage);
			break;
		case(int)TypeTower.Wind:
			target.GetComponent<Unit> ().ElementalDamage(selfProlectile.damage);
			break;
		case(int)TypeTower.Light:
			target.GetComponent<Unit> ().ElementalDamage(selfProlectile.damage);
			break;
		case(int)TypeTower.Dark:
			target.GetComponent<Unit> ().ElementalDamage(selfProlectile.damage);
			break;
		}
		Destroy (gameObject);
	}

}
