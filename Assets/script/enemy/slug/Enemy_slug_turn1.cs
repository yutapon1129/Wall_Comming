using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_slug_turn1: MonoBehaviour
{
    [SerializeField] GameObject mother;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "ground")
        {
            mother.GetComponent<Enemy_slug_R>().turn();
        }
    }
}
