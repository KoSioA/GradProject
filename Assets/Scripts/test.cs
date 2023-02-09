using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class test : MonoBehaviour
{
    public char[][] field;
    public int size = 5;
    public GameObject PathNodes;
    public GameObject TIlePrefab;
    public GameObject PathPrefab;

    [Serializable]
    public class Field {
        public char[] field;
    }
    public Field[] fields;
    public string[][] level = new string[][]
    {
        new string[] {"t", "1", "t", "t", "t" },
        new string[] {"t", "2", "3", "4", "5" },
        new string[] {"t", "t", "t", "t", "6" },
        new string[] {"t", "t", "9", "8", "7" },
        new string[] {"t", "t", "10 ", "t", "t" }
    };
    // Start is called before the first frame update
    void Start()
    {
        int size1 = level.Length;
        int size2 = fields[0].field.Length;
        field = new char[size1][];
        Dictionary<int, GameObject> paths = new Dictionary<int, GameObject>();
        for(int i = 0; i < size1; i++)
        {
            for (int y = 0; y < level[i].Length; y++)
            {
                GameObject current;
                GameObject tile;
                Transform parent;
                float tileSize = size;
                if(level[i][y] == "t")
                {
                    current = TIlePrefab;
                    parent = this.transform;
                }
                else
                {
                    current = PathPrefab;
                    parent = PathNodes.transform;
                    tileSize *= (float)1.5;
                }
                tile = Instantiate(current, new Vector3(y * size * (float)1.5, 0, i * size * (float)-1.5), Quaternion.identity);
                tile.transform.localScale = new Vector3(tileSize, (float)size/4, tileSize);
                tile.transform.parent = parent;
                int position;
                if (level[i][y] != "t" && int.TryParse(level[i][y], out position))
                {
                    tile.name = level[i][y];
                    paths.Add(position, tile);
                }
            }
        }
        GameObject previous = null;
        foreach(KeyValuePair<int, GameObject> path in paths.OrderBy(x => x.Key))
        {
            Debug.Log(path.Value.name);
            Debug.Log("prev: " + previous);
            if (previous != null)
            {
                Debug.Log("prev: " + previous.name);
                previous.GetComponent<Path>().next = path.Value;
            }
            previous = path.Value;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
