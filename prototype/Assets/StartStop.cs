﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartStop : MonoBehaviour
{
    public bool effectsOn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EffectsOn(bool value)
    {
        effectsOn = value; 
        Debug.Log(effectsOn.ToString());
    }
}