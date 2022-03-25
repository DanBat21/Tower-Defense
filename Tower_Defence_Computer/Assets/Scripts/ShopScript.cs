using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopScript : MonoBehaviour {
	public GameObject ItemPref;
	public Transform ItemGrid;
	GameLogic gl;
	public Cell selfcell;
	// Use this for initialization
	void Start () {
		gl = FindObjectOfType<GameLogic> ();
		foreach (Tower tower in gl.AllTowers) {
			GameObject temp_Item = Instantiate (ItemPref);
			temp_Item.transform.SetParent (ItemGrid, false);
			temp_Item.GetComponent<ShopItemScript> ().SetStartData (tower,selfcell);
		
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void CloseShop(){
		Destroy (gameObject);
	}
}
