using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    double health = 10;
    public float speed = 0.2f;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Move();
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collided");
        Debug.Log(collision.transform.gameObject == target);
        Debug.Log(collision.transform.gameObject.name);
        if(collision.transform.gameObject == target)
        {
            target = target.GetComponent<Path>().next;
        }
    }
    void Move()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(target.transform.position.x, this.transform.position.y, target.transform.position.z), speed);
    }
}
