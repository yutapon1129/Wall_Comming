using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_R_turm2_Slime : MonoBehaviour
{
    [SerializeField] GameObject mother;

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "ground")
        {
            mother.GetComponent<Enemy_R_Slime>().turn();
        }
    }
}
