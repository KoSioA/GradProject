using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    double health = 3;
    public float speed = 0.2f;
    public GameObject target;

    private void Start()
    {
        target = GameObject.Find("GameMaster").GetComponent<LevelSetup>().firstNode;
    }
    void Update()
    {
        Debug.Log("Updating?");
        Vector3 dir = target.transform.position - this.transform.position;
        this.transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        if(Vector3.Distance(this.transform.position, target.transform.position) < 0.2f)
        {
            target = target.GetComponent<Waypoint>().next;
            if(target == null)
            {
                Destroy(this.gameObject);
            }
        }
    }

    public void TakeDamage(float damage)
    {
        this.health -= damage;
        if(this.health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
