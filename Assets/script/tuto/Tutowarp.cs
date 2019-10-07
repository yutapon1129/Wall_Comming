using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutowarp : MonoBehaviour
{
    public string scene;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "player")
        {
            FadeManager.Instance.LoadScene(scene, 2.0f);
        }
    }
}
