using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerItem : IItem
{
    public int rarity { get; set; }

    public string type {get;set;}
    public string towerType { get; private set; }
    public float damage { get; private set; }
    public float fireRate { get; private set; }
    public TowerItem()
    {
        type = "tower";
        towerType = "normal";
    }
    public TowerItem(int rarity, string towerType, float damage, float fireRate) : this(){
        this.rarity = rarity;
        this.towerType = towerType;
        this.damage = damage * rarity;
        this.fireRate = fireRate;
    }
}
