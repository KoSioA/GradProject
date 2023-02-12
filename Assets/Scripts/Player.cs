using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    static public Player instance;

    public int health = 100;
    public int maxHealth = 100;
    GameObject[] inventory;

    private void Awake()
    {
        instance = this;
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
