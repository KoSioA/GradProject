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
        if (!Game.instance.playing)
        {
            return;
        }
        if (turret != null)
        {
            rend.material.color = Color.blue;
            return;
        }
        rend.material.color = hoverColor;
    }
    private void OnMouseExit()
    {
        if (!Game.instance.playing)
        {
            return;
        }
        rend.material.color = startColor;
    }

    private void OnMouseDown()
    {
        if (!Game.instance.playing)
        {
            return;
        }
        if (turret != null)
        {
            this.turret.GetComponent<Turret>().OpenUpgrade();
        }
        if (BuildManager.instance.GetSelectedTurret() == null)
        {
            return;
        }
        TowerItem selectedTurret = BuildManager.instance.GetSelectedTurret();
        GameObject newTurret = ToGameObject(selectedTurret, transform.position + turretOffset, transform.rotation);
        turret = newTurret;
        BuildManager.instance.removeTurret();
    }

    private GameObject ToGameObject(TowerItem tower, Vector3 position, Quaternion rotation)
    {
        GameObject turretPrefab = null;
        switch (tower.towerType)
        {
            case "normal":
                turretPrefab = BuildManager.instance.normalTurret;
                break;
            case "fast":
                turretPrefab = BuildManager.instance.fastTurret;
                break;
        }
        GameObject newTurret = Instantiate(turretPrefab, position, rotation);
        newTurret.GetComponent<Turret>().tower = tower;
        newTurret.GetComponent<Turret>().updateStats();

        return newTurret;
    }
}
