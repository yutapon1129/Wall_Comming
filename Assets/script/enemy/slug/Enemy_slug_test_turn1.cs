using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_slug_test_turn1 : MonoBehaviour
{
    [SerializeField] GameObject mother;

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "ground")
        {
            // Enemy_slug_testにあるよ
            mother.GetComponent<Enemy_slug_test>().turn_right();
            //GetComponent<BoxCollider2D>().enabled = false;
            //Invoke("collider_reborn", 0.5f);
            //Debug.Log("unti");
        }
    }

    void collider_reborn()
    {
        GetComponent<BoxCollider2D>().enabled = true;
    }
}
