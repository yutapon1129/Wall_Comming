using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_turn_Ant : MonoBehaviour
{
    [SerializeField] GameObject mother;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "ground")
        {
            mother.GetComponent<Enemy_Ant>().turn();
        }
    }
}
