using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour 
{
	public bool isGround;
	public Color BaseColor,CurrColor, DestroyColor;
	
	public GameObject ShopPref, TowerPref, DestroyPref;
	public GameObject SelfTower;

	private void OnMouseEnter()
	{
		
		if (!isGround && FindObjectsOfType<ShopScript>().Length ==0 && FindObjectsOfType<DestroyTower>().Length == 0) 
		{
			if (!SelfTower)
			GetComponent<SpriteRenderer> ().color = CurrColor;
			else
			GetComponent<SpriteRenderer>().color = DestroyColor;

		}
	}
	private void OnMouseExit()
	{ 
		GetComponent<SpriteRenderer> ().color = BaseColor;
	}

	private void OnMouseDown()
	{
		if (!isGround && FindObjectsOfType<ShopScript> ().Length == 0 && GameManager.Instance.canSpawn && FindObjectsOfType<DestroyTower>().Length == 0) {
			if (!SelfTower)
			{
				GameObject shopobj = Instantiate(ShopPref);
				shopobj.transform.SetParent(GameObject.Find("Canvas").transform, false);
				shopobj.GetComponent<ShopScript>().selfcell = this;
			}

			else
			{
				GameObject townDestr = Instantiate(DestroyPref);
				townDestr.transform.SetParent(GameObject.Find("Canvas").transform, false);
				townDestr.GetComponent<DestroyTower>().Selfcell = this;
			}
		}
	}

	public void Build(Tower tower)
	{
		GameObject temp_tower = Instantiate (TowerPref);	
		temp_tower.transform.SetParent (transform, false);
		temp_tower.transform.position = transform.position;
		
		temp_tower.GetComponent<Towersrc> ().selftype = (TypeTower)tower.type;
		SelfTower = temp_tower;
		FindObjectOfType<ShopScript> ().CloseShop();
	}

	public void DestroyTower()
    {
		GameManager.Instance.GameMoney += (SelfTower.GetComponent<Towersrc>().selftower.Price / 2);
		Destroy(SelfTower);
    }
}
