using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSetup : MonoBehaviour
{
    public static LevelSetup instance;
    private void Awake()
    {
        instance = this;
    }
    public char[][] field;
    public int size = 2;
    [Tooltip("DON'T TOUCH! Code does all the work here")]
    public GameObject firstNode;
    [Header("World Objects")]
    public GameObject Spawner;
    public GameObject Base;
    public GameObject Camera;

    [Header("Groupings")]
    public GameObject PathNodes;
    public GameObject TileNodes;
    public GameObject Waypoints;

    [Header("Prefabs")]
    public GameObject TilePrefab;
    public GameObject PathPrefab;
    public GameObject WaypointPrefab;

    void Start()
    {
        BuildLevel(Level.level1);
    }
    public void BuildLevel(Level lvl)
    {
        string[][] level = lvl.level;
        string[][] path = lvl.path;
        Vector3 spawnPoint = lvl.spawnPoint;
        Vector3 basePoint = lvl.basePoint;

        Dictionary<int, GameObject> paths = new Dictionary<int, GameObject>();
        for (int i = 0; i < level.Length; i++)
        {
            for (int y = 0; y < level[i].Length; y++)
            {
                GameObject current;
                GameObject tile;
                Transform parent;
                float tileSize = size;
                if (level[i][y] == "t")
                {
                    current = TilePrefab;
                    parent = TileNodes.transform;
                }
                else
                {
                    current = PathPrefab;
                    parent = PathNodes.transform;
                    tileSize *= (float)1.5;
                }
                tile = Instantiate(current, new Vector3(y * size * (float)1.5, 0, i * size * (float)-1.5), Quaternion.identity);
                tile.transform.localScale = new Vector3(tileSize, (float)size / 4, tileSize);
                tile.transform.parent = parent;
                int position;
                if (path[i][y] != "t" && int.TryParse(path[i][y], out position))
                {
                    GameObject waypoint = Instantiate(WaypointPrefab, new Vector3(y * size * (float)1.5, size * 0.25f + 0.7f, i * size * (float)-1.5), Quaternion.identity);
                    waypoint.name = position.ToString();
                    waypoint.transform.parent = Waypoints.transform;
                    paths.Add(position, waypoint);
                }
            }
        }

        GameObject previous = null;
        foreach (KeyValuePair<int, GameObject> pathKvp in paths.OrderBy(x => x.Key))
        {
            if (previous != null)
            {
                previous.GetComponent<Waypoint>().next = pathKvp.Value;
            }
            else
            {
                firstNode = pathKvp.Value;
            }
            previous = pathKvp.Value;
        }
        Base.transform.position = new Vector3(basePoint.x * size * 1.5f, Spawner.transform.position.y, -basePoint.z * size * 1.5f);
        Spawner.transform.position = new Vector3(spawnPoint.x * size * 1.5f, Spawner.transform.position.y, -spawnPoint.z * size * 1.5f);
        PositionCamera(lvl);
    }

    private void PositionCamera(Level lvl)
    {
        string[][] level = lvl.level;
        float xPos = level.Length * size * (float)1.5;
        float zPos = level[0].Length * size * (float)1.5;
        Camera.transform.position = new Vector3(xPos/2, Camera.transform.position.y, zPos/-2 - zPos/10);
    }

    public void BuildRandomLevel()
    {
        System.Random rand = new System.Random();
        Level current = Level.levels[rand.Next(Level.levels.Length)];
        PickupTurrets();
        TeardownLevel();
        BuildLevel(current);
    }
    public void DeleteTowers()
    {
        foreach(GameObject node in GameObject.FindGameObjectsWithTag("TowerNode"))
        {
            node.GetComponent<Node>().RemoveTurret();
        }
        foreach (GameObject turret in GameObject.FindGameObjectsWithTag("Turret"))
        {
            Destroy(turret);
        }
    }
    public void PickupTurrets()
    {
        foreach (GameObject turret in GameObject.FindGameObjectsWithTag("Turret"))
        {
            Player.instance.inventory.Add(turret.GetComponent<Turret>().tower);
            Destroy(turret);
        }
        foreach (GameObject node in GameObject.FindGameObjectsWithTag("TowerNode"))
        {
            node.GetComponent<Node>().RemoveTurret();
        }
        Ui.instance.LoadTurrets();
    }
    public void TeardownLevel()
    {
        foreach (GameObject node in GameObject.FindGameObjectsWithTag("TowerNode"))
        {
            Destroy(node);
        }
        foreach (GameObject node in GameObject.FindGameObjectsWithTag("waypoint"))
        {
            Destroy(node);
        }
        foreach (GameObject node in GameObject.FindGameObjectsWithTag("Path"))
        {
            Destroy(node);
        }
    }
}
