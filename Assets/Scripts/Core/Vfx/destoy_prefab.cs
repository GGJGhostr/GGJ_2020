﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destoy_prefab : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DestroyThisPrefab()
    {
        Destroy(gameObject, 0.0f);
    }
}
