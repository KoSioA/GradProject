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
    }, new Vector3(1, 0, 0));
    public string[][] level;
    public string[][] path;
    public Vector3 spawnPoint;
    public Level(string[][] level, string[][] path, Vector3 spawn)
    {
        this.level = level;
        this.path = path;
        this.spawnPoint = spawn;
    }
}
