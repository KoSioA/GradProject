using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    static public Player instance;

    public int health = 100;
    public int maxHealth = 100;
    public List<IItem> inventory;
    //public List<TowerItem> towers;
    public int money = 0;

    private void Awake()
    {
        instance = this;
        inventory = new List<IItem> { new TowerItem(1, "normal", 1f, 1f, 10f), 
            new TowerItem(1, "fast", 1f, 10f, 5f), 
            new TowerItem(2, "normal", 1f, 1f, 10f),
            new TowerItem(1, "fast", 1f, 10f, 5f),
            new TowerItem(1, "fast", 1f, 10f, 5f),
            new TowerItem(1, "fast", 1f, 10f, 5f),
            new TowerItem(1, "fast", 1f, 10f, 5f),
            new TowerItem(1, "fast", 1f, 10f, 5f),
            new TowerItem(1, "fast", 1f, 10f, 5f),
            new TowerItem(1, "fast", 1f, 10f, 5f),
            new TowerItem(1, "fast", 1f, 10f, 5f),
            new TowerItem(1, "fast", 1f, 10f, 5f),
            new TowerItem(3, "normal", 1f, 1f, 10f) };
        TowerItem tower = (TowerItem)inventory[2];
        tower.AddUpgrade(UpgradeItem.CreateRandom(), 0);
        tower.AddUpgrade(UpgradeItem.CreateRandom(), 0);
    }
    public void TakeDamage(int damage)
    {
        this.health -= damage;
        if(this.health <= 0)
        {
            Game.instance.playing = false;
        }
    }
    public void GetMoney(int addedMoney)
    {
        this.money += addedMoney;
    }
}
