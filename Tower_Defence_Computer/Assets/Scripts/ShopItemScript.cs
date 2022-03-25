using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ShopItemScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler {

	Tower selfTower;
	Cell selfcell;
	public Image Logo;
	public Text Name, Price;

	public Color BaseColor, CurrColor, DestroyColor;

	public void SetStartData(Tower tower,Cell cell){
		selfTower = tower;
		Logo.sprite = tower.Spr;
		Name.text = tower.Name;
		Price.text = tower.Price.ToString();
		selfcell = cell;
	}

	public void OnPointerEnter(PointerEventData eventdata){
		GetComponent<Image>().color = CurrColor;
	}
	public void OnPointerExit(PointerEventData eventdata){
		GetComponent<Image>().color = BaseColor;
	}
	public void OnPointerClick(PointerEventData eventdata){
		if (GameManager.Instance.GameMoney >= selfTower.Price) {
			selfcell.Build (selfTower);
			GameManager.Instance.GameMoney -= selfTower.Price;
		}
	}
}
