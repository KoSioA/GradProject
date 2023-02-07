using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public char[][] field;
    public int size = 5;
    public GameObject towerNodes;
    public GameObject TIlePrefab;
    public GameObject PathPrefab;

    [Serializable]
    public class Field {
        public char[] field;
    }
    public Field[] fields;
    public char[][] level = new char[][]
    {
        new char[] {'t', 'p', 't', 't', 't' },
        new char[] {'t', 'p', 'p', 'p', 'p' },
        new char[] {'t', 't', 't', 't', 'p' },
        new char[] {'t', 't', 'p', 'p', 'p' },
        new char[] {'t', 't', 'p', 't', 't' }
    };
    // Start is called before the first frame update
    void Start()
    {
        int size1 = level.Length;
        int size2 = fields[0].field.Length;
        field = new char[size1][];
        for(int i = 0; i < size1; i++)
        {
            field[i] = level[i];
            for (int y = 0; y < field[i].Length; y++)
            {
                GameObject current = field[i][y] == 't' ? TIlePrefab : PathPrefab;
                GameObject tile = Instantiate(current, new Vector3(y * 5, 0, i * -5), Quaternion.identity);;
                tile.transform.parent = transform;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
