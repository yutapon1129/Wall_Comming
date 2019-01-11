using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    void Update()
    {
        transform.Translate(-0.005f, 0, 0);
        if (transform.position.x < -240)
        {
            transform.position = new Vector3(240, 0, 0);
        }
    }
}