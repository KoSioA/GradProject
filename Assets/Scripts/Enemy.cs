using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public double health = 3;
    public float speed = 0.2f;
    public GameObject target;
    public int worth = 10;
    public int damage = 10;

    private void Start()
    {
        target = GameObject.Find("GameMaster").GetComponent<LevelSetup>().firstNode;
    }
    void Update()
    {
        Vector3 dir = target.transform.position - this.transform.position;
        this.transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        if(Vector3.Distance(this.transform.position, target.transform.position) < 0.2f)
        {
            target = target.GetComponent<Waypoint>().next;
            if(target == null)
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
        BaseScript.instance.AddItem(TowerItem.CreateRandom());
        Destroy(this.gameObject);
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
