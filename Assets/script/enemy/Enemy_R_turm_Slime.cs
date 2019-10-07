using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_R_turm_Slime : MonoBehaviour
{
    [SerializeField] GameObject mother;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "ground")
        {
            mother.GetComponent<Enemy_R_Slime>().turn();
        }
    }
}
