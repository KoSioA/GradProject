using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSetup : MonoBehaviour
{
    public char[][] field;
    public int size = 2;
    public GameObject firstNode;
    public GameObject Spawner;

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
        string[][] level = Level.level1.level;
        string[][] path = Level.level1.path;
        Vector3 spawnPoint = Level.level1.spawnPoint;

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
                    GameObject waypoint = Instantiate(WaypointPrefab, new Vector3(y * size * (float)1.5, size * 0.75f, i * size * (float)-1.5), Quaternion.identity);
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

        Spawner.transform.position = new Vector3(spawnPoint.x * size * 1.5f, Spawner.transform.position.y, spawnPoint.z * size * 1.5f);

    }
}
