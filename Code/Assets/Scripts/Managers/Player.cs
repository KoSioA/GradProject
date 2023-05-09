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
        inventory = new List<IItem> { new TowerItem(1, "normal", 1f, 1f, 10f) };
        inventory.Add(UpgradeItem.CreateRandom());
        inventory.Add(TowerItem.CreateRandom());
    }
    public void TakeDamage(int damage)
    {
        this.health -= damage;
        if(this.health <= 0)
        {
            Game.instance.LoseGame();
        }
    }
    public void GetMoney(int addedMoney)
    {
        this.money += addedMoney;
    }

    public void Reset()
    {
        money = 0;
        health = maxHealth;
        inventory.Clear();
        inventory.Add(TowerItem.CreateRandom());
    }
}
