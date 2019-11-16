using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_slug_test_turn2 : MonoBehaviour
{
    [SerializeField] GameObject mother;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "ground")
        {
            // Enemy_slug_testにあるよ
            mother.GetComponent<Enemy_slug_test>().turn_left();
            //GetComponent<BoxCollider2D>().enabled = false;
            //Invoke("collider_reborn", 0.5f);
            
        }
    }

    void collider_reborn()
    {
        GetComponent<BoxCollider2D>().enabled = true;
    }
}
