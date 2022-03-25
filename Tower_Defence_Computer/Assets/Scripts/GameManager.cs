using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;	

public class GameManager : MonoBehaviour {
	public static GameManager Instance;
	public Text MoneyText,HPText,WaveText;
	public int GameMoney, HP,Wave;
	public GameObject Menu;
	public bool canSpawn = false;
	void Awake () {
		Instance = this;
	}

	// Update is called once per frame
	void Update () {
		MoneyText.text = "Money:"+GameMoney.ToString ();
		HPText.text = "HP:" + HP.ToString ();
		WaveText.text = "Wave:" + Wave.ToString ();
		if (Input.GetKeyDown (KeyCode.Escape)) {
			ToMenu ();
		}	
	}

	public void playBtn()
	{
		foreach (Cell cs in FindObjectsOfType<Cell>())
			Destroy(cs.gameObject);

		foreach (Towersrc ts in FindObjectsOfType<Towersrc>())
			Destroy(ts.gameObject);

		foreach (Unit es in FindObjectsOfType<Unit>())
			Destroy(es.gameObject);

		GameMoney = 30;

		FindObjectOfType<LevelManager>().CreateLevel();
		FindObjectOfType<Spawner>().spawnCount = 0;
		FindObjectOfType<Spawner>().spawn_time = 4;

		//Destroy (GameObject.Find ("Menu"));
		Menu.SetActive (false);
		canSpawn = true;
				
	}

	public void QuitBtn()
	{
		Application.Quit();
	}

	public void ToMenu()
	{
		Menu.SetActive (true);
	    canSpawn = false;

		if (FindObjectsOfType<ShopScript>().Length >0)
		Destroy(FindObjectOfType<ShopScript>().gameObject);
	}

	public void EndingMenu(){
		foreach(Unit un in FindObjectsOfType<Unit>())
			Destroy(un.gameObject);
		foreach(Towersrc t in FindObjectsOfType<Towersrc>())
			Destroy(t.gameObject);
		foreach(TowerProject tp in FindObjectsOfType<TowerProject>())
			Destroy(tp.gameObject);
		Menu.SetActive (true);
		canSpawn = false;
	}

	// Use this for initialization
	public void LosingHP(){
		if (HP > 1)
			HP--;
		else
			EndingMenu ();
		
	}
}
