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

    private GameObject selectedTurret;
    public GameObject normalTurret;
    public GameObject fastTurret;

    private void Start()
    {
        selectedTurret = normalTurret;
    }
    public void changeTurret(GameObject turret)
    {
        selectedTurret = turret;
    }
    public GameObject GetSelectedTurret()
    {
        return selectedTurret;
    }
}
