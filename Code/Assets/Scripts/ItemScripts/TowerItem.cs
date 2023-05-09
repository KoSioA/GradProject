using System;
using System.Linq;
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
    public UpgradeItem[] upgrades;
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
        this.upgrades = new UpgradeItem[this.rarity];
    }
    /// <summary>
    /// returns a dictionary with "damage", "range" and "fireRate"
    /// </summary>
    public Dictionary<string, float> getStats()
    {
        Dictionary<string, float> stats = new Dictionary<string, float>();
        stats.Add("damage", this.damage);
        stats.Add("range", this.range);
        stats.Add("fireRate", this.fireRate);
        foreach(UpgradeItem upgrade in this.upgrades)
        {
            if(upgrade == null)
            {
                continue;
            }
            stats["damage"] += upgrade.damageMod;
            stats["range"] += upgrade.rangeMod;
            stats["fireRate"] += upgrade.fireRateMod;
        }
        return stats;
    }
    public void AddUpgrade(UpgradeItem upgrade, int position)
    {
        if(this.upgrades.Length <= position)
        {
            return;
        }
        if(this.upgrades[position] != null)
        {

            Player.instance.inventory.Add(this.upgrades[position]);
        }
        this.upgrades[position] = upgrade;
    }
    public static TowerItem CreateRandom()
    {
        System.Random rand = new System.Random();
        int rarity = RandRarity();
        int tt = rand.Next(1, 3);
        string towerType = "normal";

        float damageModifier = 0;
        float baseDamage = 0;

        float fireRateModifier = 0;
        float baseFireRate = 0;

        float baseRange = 0;
        float rangeModifier = 0;

        switch (tt)
        {
            case 1:
                towerType = "normal";
                damageModifier = 5;
                baseDamage = 10;

                baseFireRate = 1;
                fireRateModifier = 2;

                baseRange = 8;
                rangeModifier = 4;
                break;
            case 2:
                towerType = "fast";
                damageModifier = 2;
                baseDamage = 1;

                baseFireRate = 10;
                fireRateModifier = 5;

                baseRange = 5;
                rangeModifier = 3;
                break;
        }
        float damage = baseDamage + damageModifier * (float)rand.NextDouble();
        float fireRate = baseFireRate + fireRateModifier * (float)rand.NextDouble();
        float range = baseRange + rangeModifier * (float)rand.NextDouble();
        TowerItem output = new TowerItem(rarity, towerType, damage, fireRate, range);
        return output;

    }
    
    private static int RandRarity()
    {
        System.Random rand = new System.Random();
        int random = rand.Next(1, 11);//gives a random value between 1 and 10 including 1 and 10.
        int rarity = 1;
        if(random >= 7)
        {
            rarity = 2;
        }
        if(random == 10)
        {
            rarity = 3;
        }
        return rarity;
    }

    override public string ToString()
    {
        string output = "";
        int filledUpgrades = upgrades.Where(x => x != null).Count();
        output += this.towerType + " tower\n" +
                  "Damage: " + Math.Round(this.damage, 2) + "\n" +
                  "FireRate: " + Math.Round(this.fireRate, 2) + "\n" +
                  "Range: " + Math.Round(this.range, 2) + "\n" +
                  "Upgrades: " + filledUpgrades + "\n" +
                  "Rarity: " + this.rarity;

        return output;
    }
}
