using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake()
    {
        instance = this;
    }

    public TowerItem selectedTurret;
    public GameObject normalTurret;
    public GameObject fastTurret;

    private void Start()
    {
        selectedTurret = null;
        //selectedTurret = Player.instance.towers[0];
    }
    public void changeTurret(TowerItem turret)
    {
        selectedTurret = turret;
    }
    public TowerItem GetSelectedTurret()
    {
        return selectedTurret;
    }
    public void removeTurret()
    {
        Player.instance.towers.Remove(selectedTurret);
        this.Deselect();
        Ui.instance.LoadTurrets();
    }
    public void Deselect()
    {
        selectedTurret = null;
    }
}
