﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Auto_SeaMoving : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-0.001f, 0, 0);
        if (transform.position.x < -1200)
        {
            transform.position = new Vector3(1200, 0, 0);
        }
    }
}
