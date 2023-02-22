using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public double health = 3;
    public double maxHealth = 3;
    public float speed = 0.2f;
    public GameObject target;
    public int worth = 10;
    public int damage = 10;
    private int dropChance = 20;
    public bool isBoss = false;

    private void Start()
    {
        target = GameObject.Find("GameMaster").GetComponent<LevelSetup>().firstNode;
    }
    void Update()
    {
        if (!Game.instance.playing)
        {
            return;
        }
        if(this.health > this.maxHealth)
        {
            this.health = this.maxHealth;
        }
        this.Move();
    }
    private void Move()
    {
        Vector3 dir = target.transform.position - this.transform.position;
        this.transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(this.transform.position, target.transform.position) < 0.2f)
        {
            target = target.GetComponent<Waypoint>().next;
            if (target == null)
            {
                Player.instance.TakeDamage(this.damage);
                Destroy(this.gameObject);
                return;
            }
        }
    }
    private void Die()
    {
        Player.instance.GetMoney(this.worth);
        this.Drop();
        Destroy(this.gameObject);
    }
    private void Drop()
    {
        if (this.isBoss)
        {
            BaseScript.instance.AddItem(TowerItem.CreateRandom());
            return;
        }
        System.Random rand = new System.Random();
        if(rand.Next(1, 101) <= this.dropChance)
        {
            BaseScript.instance.AddItem(TowerItem.CreateRandom());
        }
    }
    public void TakeDamage(float damage)
    {
        this.health -= damage;
        if(this.health <= 0)
        {
            this.Die();
        }
    }
}
