using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UpgradeItem : IItem
{
    public int rarity { get; set; }
    public string type { get; set; }
    public float damageMod { get; private set; }
    public float rangeMod { get; private set; }
    public float fireRateMod { get; private set; }
    private static float damageModifier = 3;
    private static float rangeModifier = 5;
    private static float fireRateModifier = 3;

    public UpgradeItem()
    {
        type = "upgrade";
    }
    public UpgradeItem(int rarity, float damageMod, float rangeMod, float fireRatemod) : this()
    {
        this.rarity = rarity;
        this.damageMod = damageMod;
        this.rangeMod = rangeMod;
        this.fireRateMod = fireRatemod;
    }
    public static UpgradeItem CreateRandom()
    {
        System.Random rand = new System.Random();
        int rarity = RandRarity();
        float damage = 0;
        float range = 0;
        float fireRate = 0;
        for(int i = 0; i < rarity; i++)
        {
            int buffType = rand.Next(1, 4);
            switch (buffType)
            {
                case 1:
                    damage += (float)rand.NextDouble() * damageModifier;
                    break;
                case 2:
                    range += (float)rand.NextDouble() * rangeModifier;
                    break;
                case 3:
                    fireRate += (float)rand.NextDouble() * fireRateModifier;
                    break;
            }
        }
        return new UpgradeItem(rarity, damage, range, fireRate);
    }
    private static int RandRarity()
    {
        System.Random rand = new System.Random();
        int random = rand.Next(1, 11);//gives a random value between 1 and 10 including 1 and 10.
        int rarity = 1;
        if (random >= 7)
        {
            rarity = 2;
        }
        if (random == 10)
        {
            rarity = 3;
        }
        return rarity;
    }
}
