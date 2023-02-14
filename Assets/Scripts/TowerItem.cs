using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerItem : IItem
{
    public int rarity { get; set; }

    public string type {get;set;}
    public string towerType { get; private set; }
    public float damage { get; private set; }
    public float range { get; private set; }
    public float fireRate { get; private set; }
    public TowerItem()
    {
        type = "tower";
        towerType = "normal";
        range = 10;
    }
    public TowerItem(int rarity, string towerType, float damage, float fireRate, float range) : this(){
        this.rarity = rarity;
        this.towerType = towerType;
        this.damage = damage * rarity;
        this.fireRate = fireRate;
        this.range = range;
    }

    override public string ToString()
    {
        string output = "";

        output += this.towerType + " tower\n" +
                  "Damage: " + this.damage + "\n" +
                  "FireRate: " + this.fireRate + "\n" +
                  "Range: " + this.range + "\n" +
                  "Rarity: " + this.rarity;

        return output;
    }
}
