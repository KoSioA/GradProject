using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Level 
{
    public static Level level1 = new Level(new string[][]
    {
        new string[] {"t", "1", "t", "t", "t" },
        new string[] {"t", "2", "3", "4", "5" },
        new string[] {"t", "t", "t", "t", "6" },
        new string[] {"t", "t", "9", "8", "7" },
        new string[] {"t", "t", "10 ", "t", "t" }
    }, new string[][]
    {
        new string[] {"t", "p", "t", "t", "t" },
        new string[] {"t", "1", "p", "p", "2" },
        new string[] {"t", "t", "t", "t", "p" },
        new string[] {"t", "t", "4", "p", "3" },
        new string[] {"t", "t", "5 ", "t", "t" }
    }, new Vector3(1, 0, 0), new Vector3(2, 0, 4));
    public static Level level2 = new Level(new string[][]
    {
        new string[] {"t", "8", "7", "6", "t", "21", "t" },
        new string[] {"t", "9", "t", "5", "t", "20", "t" },
        new string[] {"1", "2", "3", "4", "t", "19", "t" },
        new string[] {"t", "10", "t", "t", "t", "18", "t" },
        new string[] {"t", "11", "t", "t", "t", "17", "t" },
        new string[] {"t", "12", "13", "14", "15", "16", "t" },
        new string[] {"t", "t", "t", "t", "t", "t", "t" }
    }, new string[][]
    {
        new string[] {"t", "4", "t", "3", "t", "7", "t" },
        new string[] {"t", "t", "t", "t", "t", "t", "t" },
        new string[] {"1", "t", "t", "2", "t", "t", "t" },
        new string[] {"t", "t", "t", "t", "t", "t", "t" },
        new string[] {"t", "t", "t", "t", "t", "t", "t" },
        new string[] {"t", "5", "t", "t", "t", "6", "t" },
        new string[] {"t", "t", "t", "t", "t", "t", "t" }
    }, new Vector3(0, 0, 2), new Vector3(5, 0, 0));
    public string[][] level;
    public string[][] path;
    public Vector3 spawnPoint;
    public Vector3 basePoint;
    public static Level[] levels = new Level[] { level1, level2};
    public Level(string[][] level, string[][] path, Vector3 spawn, Vector3 basePoint)
    {
        this.level = level;
        this.path = path;
        this.spawnPoint = spawn;
        this.basePoint = basePoint;
    }
}
