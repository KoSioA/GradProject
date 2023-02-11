using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    private float speed = 70f;

    public void Target(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Destroy(this.gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distThisFrame = speed * Time.deltaTime;
        if(dir.magnitude <= distThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distThisFrame, Space.World);
    }

    void HitTarget()
    {
        Enemy enemy = target.GetComponent<Enemy>();
        enemy.TakeDamage(1);
        Destroy(this.gameObject);
    }
}
