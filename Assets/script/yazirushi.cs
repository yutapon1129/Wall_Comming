using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class yazirushi : MonoBehaviour
{
    GameObject objText;
    public GameObject Arrows;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            Debug.Log("接触");

            Arrows.SetActive(true);

            this.objText = GameObject.Find("Text_1");
            objText.GetComponent<Text>().enabled = true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            Debug.Log("破壊");

            Arrows.SetActive(false);

            this.objText = GameObject.Find("Text_1");
            objText.GetComponent<Text>().enabled = false;

        }
    }

}
