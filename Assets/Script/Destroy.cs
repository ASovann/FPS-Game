﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    [SerializeField]
    private int time = 1;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, time);
    }
    
}
