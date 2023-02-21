using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public Dictionary<string, float> wave;
    public float standardDelay = 5f;
    public Wave[] waves = new Wave[] {
        new Wave(new string[] {"normal", "normal"},
                 new float[] {}),
        new Wave(new string[] {"normal", "normal", "normal", "normal", "normal"},
                 new float[] {}),
    };
    public Wave() { }
    public Wave(List<string> enemies, List<float> delays) : this(enemies.ToArray(), delays.ToArray())
    {
    }
    public Wave(string[] enemies, float[] delays)
    {
        wave = new Dictionary<string, float>();
        for(int i = 0; i < enemies.Length; i++)
        {
            if(i < delays.Length)
            {
                wave.Add(enemies[i], delays[i]);
                continue;
            }
            wave.Add(enemies[i], standardDelay);
        }
    }
}
