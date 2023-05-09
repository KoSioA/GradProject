using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform target;

    [Header("Stats")]
    public float range = 15f;
    public float fireRate = 1f;
    public float damage;
    private float fireCountdown = 0f;

    [Header("Unity fields")]
    public string enemytag = "Enemy";

    public Transform rotatingPart;
    public float rotSpeed = 10f;

    public GameObject bulletPrefab;
    public Transform firePoint;

    public TowerItem tower;

    

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemytag);
        float shortestDist = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach(GameObject enemy in enemies)
        {
            float distToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distToEnemy < shortestDist)
            {
                shortestDist = distToEnemy;
                nearestEnemy = enemy;
            } 
        }
        if(nearestEnemy != null && shortestDist <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!Game.instance.playing)
        {
            return;
        }
        if (target == null)
        {
            return;
        }
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rot = Quaternion.Lerp(rotatingPart.rotation, lookRotation, Time.deltaTime * rotSpeed).eulerAngles;
        rotatingPart.rotation = Quaternion.Euler(0f, rot.y, 0f);

        if(fireCountdown <= 0)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }
        fireCountdown -= Time.deltaTime;
    }
    public void OpenUpgrade()
    {
        UpgradeWindow.instance.OpenWindow(tower);
    }
    public void updateStats()
    {
        var newStats = this.tower.getStats();
        this.damage = newStats["damage"];
        this.range = newStats["range"];
        this.fireRate = newStats["fireRate"];
    }

    private void Shoot()
    {
        GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet == null)
        {
            return;
        }
        bullet.Target(target);
        bullet.setDamage(damage);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
