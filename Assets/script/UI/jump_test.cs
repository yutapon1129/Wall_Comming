﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump_test : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Debug.Log("Touched!");
        }
    }
}
