using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public Dictionary<string, float> wave;
    public List<string> enemies;
    public List<float> delays;
    public float standardDelay = 0.5f;
    public static Wave[] waves = new Wave[] {
        new Wave(new string[] {"normal", "normal"},
                 new float[] {}),
        new Wave(new string[] {"normal", "normal", "normal", "normal", "normal"},
                 new float[] {}),
        new Wave(new string[] {"normal", "normal", "strong", "normal", "normal"},
                 new float[] {0.2f, 0.2f, 0.2f, 0.2f, 0.2f, 0.2f}),
        new Wave(new string[] {"normal", "normal", "normal", "normal", "normal", "normal", "normal", "normal", "normal"},//3
                 new float[] {0.2f, 0.5f, 0.5f, 0.5f, 0.2f, 0.2f, 0.2f, 0.2f, 0.2f}),
        new Wave(new string[] {"normal", "normal", "normal", "normal", "normal", "normal", "normal", "normal", "normal", "normal", "normal", "normal", "normal"},
                 new float[] {0.5f, 0.5f, 0.5f, 0.5f, 0.5f, 0.5f, 0.2f, 0.2f, 0.2f, 0.2f,0.2f, 0.2f, 0.2f, 0.2f,0.2f, 0.2f, 0.2f, 0.2f,}),
        new Wave(new string[] {"normal", "normal", "strong", "normal", "normal"},
                 new float[] {}),
        new Wave(new string[] {"normal", "strong", "normal", "strong", "mornal"}, //6
                 new float[] {}),
        new Wave(new string[] {"normal", "normal", "strong", "strong", "strong", "strong", "strong", "strong", "strong", "strong", "normal", "normal" },
                 new float[] {0.5f, 0.5f, 0.2f, 0.2f, 0.2f, 0.2f, 0.2f, 0.2f, 0.2f, 0.2f, 0.5f, 0.5f}),
        new Wave(new string[] {"strong", "strong", "strong", "strong", "fast", "normal", "normal", "strong", "strong"},
                 new float[] {}),
        new Wave(new string[] {"fast", "fast", "fast", "strong", "strong", "fast", "fast"},
                 new float[] {0.1f, 0.1f, 0.1f, 0.5f, 0.5f, 0.5f, 0.2f, 0.2f, 0.2f}),
        new Wave(new string[] {"fast", "fast", "smallBoss", "strong", "strong"},//10
                 new float[] {}),
        new Wave(new string[] { "strong", "strong", "strong", "strong", "normal", "fast", "fast", "fast", "fast", "fast", "fast", "normal", "normal", "normal", "normal", "strong", "strong"},
                 new float[] {}),
        new Wave(new string[] { "fast", "fast", "fast", "fast", "fast", "fast", "fast", "fast", "fast", "fast", "fast", "fast", "fast", "fast", "fast", "fast", "fast", "fast"},
                 new float[] { 0.2f, 0.2f, 0.2f, 0.2f, 0.2f, 0.2f, 0.2f, 0.2f, 0.2f, 0.2f, 0.2f, 0.2f, 0.2f, 0.2f, 0.2f, 0.2f, 0.2f, 0.2f, 0.2f, 0.2f,}),
        new Wave(new string[] {"normal", "normal", "normal", "normal", "normal"},
                 new float[] {}),
        new Wave(new string[] {"normal", "normal", "normal", "normal", "normal"},
                 new float[] {}),
        new Wave(new string[] {"normal", "normal", "normal", "normal", "normal"},//15
                 new float[] {}),
        new Wave(new string[] {"normal", "normal", "normal", "normal", "normal"},
                 new float[] {}),
        new Wave(new string[] {"normal", "normal", "normal", "normal", "normal"},
                 new float[] {}),
        new Wave(new string[] {"normal", "normal", "normal", "normal", "normal"},
                 new float[] {}),
        new Wave(new string[] {"normal", "normal", "normal", "normal", "normal"},
                 new float[] {}),
        new Wave(new string[] {"normal", "normal", "normal", "normal", "normal"},//20
                 new float[] {})
    };
    public Wave() { }
    public Wave(List<string> enemies, List<float> delays) : this(enemies.ToArray(), delays.ToArray())
    {
    }
    public Wave(string[] enemies, float[] delays)
    { /*
        wave = new Dictionary<string, float>();
        for(int i = 0; i < enemies.Length; i++)
        {
            if(i < delays.Length)
            {
                wave.Add(enemies[i], delays[i]);
                continue;
            }
            wave.Add(enemies[i], standardDelay);
        }*/
        this.enemies = new List<string>();
        this.delays = new List<float>();
        this.enemies.AddRange(enemies);
        for (int i = 0; i < enemies.Length; i++)
        {
            if (i < delays.Length)
            {
                this.delays.Add(delays[i]);
                continue;
            }
            this.delays.Add(standardDelay);
        }
    }
}
