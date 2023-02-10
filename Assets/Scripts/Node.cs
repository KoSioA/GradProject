using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    private Color startColor;
    private Renderer rend;

    private GameObject turret;
    private Vector3 turretOffset;
    
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        turretOffset = new Vector3(0, this.transform.lossyScale.y/2, 0);
    }
    private void OnMouseEnter()
    {
        if(turret != null)
        {
            rend.material.color = Color.red;
            return;
        }
        rend.material.color = hoverColor;
    }
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    private void OnMouseDown()
    {
        if(turret != null)
        {
            return;
        }
        GameObject selectedTurret = BuildManager.instance.GetSelectedTurret();
        turret = Instantiate(selectedTurret, transform.position + turretOffset, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
