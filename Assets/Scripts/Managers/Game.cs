using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game instance;
    public bool playing = false;
    private void Awake()
    {
        instance = this;
    }
}
