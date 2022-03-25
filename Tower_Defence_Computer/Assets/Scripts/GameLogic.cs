using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public struct Tower{
	public string Name;
	public int type, Price;
	public float range,Cooldown, currCooldown;
	public Sprite Spr;

	public Tower(string Name,int type,float range, float cd,int Price,string path){
		this.Name = Name;
		this.type = type;
		this.range = range;
		Cooldown = cd;
		this.Price = Price;
		Spr = Resources.Load<Sprite> (path);
		currCooldown = 0;
	}

}
public struct Towerprojectile{
	public float speed;
	public double damage;
	public Sprite Spr;
	public Towerprojectile(float speed, double dmg,string path){
		this.speed = speed;
		damage = dmg;
		Spr = Resources.Load<Sprite> (path);
	}
}
public enum TypeTower{
	Fire,Water,Earth,Wind,Light,Dark
}
public struct Enemy{
	public float Speed, Startspeed,Health,MaxHealth;
	public int type;
	public Sprite spr;
	public Enemy(int type, float speed,float health,string path){
		this.type = type;
		MaxHealth = Health = health;
		Startspeed = Speed = speed;
		spr = Resources.Load<Sprite> (path);
	}

}

public class GameLogic : MonoBehaviour {
	public List<Tower> AllTowers =  new List<Tower>();
	public List<Towerprojectile> Allprojectiles = new List<Towerprojectile>();
	public List<Enemy> AllEnemies = new List<Enemy>();
	public void Awake(){
		AllTowers.Add (new Tower ("Fire",0,50, 0.2f,10, "TowerSpr/Fire"));
		AllTowers.Add (new Tower ("Water",1,80, 0.3f,10, "TowerSpr/Water"));
		AllTowers.Add (new Tower ("Earth",2,90, 0.7f, 10,"TowerSpr/Earth"));
		AllTowers.Add (new Tower ("Wind",3,170, 0.6f, 10,"TowerSpr/Wind"));
		AllTowers.Add (new Tower ("Light",4,180, 0.1f, 30,"TowerSpr/Light"));
		AllTowers.Add (new Tower ("Dark",5,90, 0.3f,30, "TowerSpr/Dark"));
		Allprojectiles.Add (new Towerprojectile (110, 6, "TowerProject/Fire"));
		Allprojectiles.Add (new Towerprojectile (130, 5, "TowerProject/Water"));
		Allprojectiles.Add (new Towerprojectile (100, 8, "TowerProject/Earth"));
		Allprojectiles.Add (new Towerprojectile (150, 4, "TowerProject/Wind"));
		Allprojectiles.Add (new Towerprojectile (100, 15, "TowerProject/Light"));
		Allprojectiles.Add (new Towerprojectile (100, 35, "TowerProject/Dark"));
		AllEnemies.Add(new Enemy(0,4,40,"EnemySpr/Fire"));
		AllEnemies.Add(new Enemy(1,3,50,"EnemySpr/Water"));
		AllEnemies.Add(new Enemy(2,2,60,"EnemySpr/Earth"));
		AllEnemies.Add(new Enemy(3,5,30,"EnemySpr/Wind"));
	}

}