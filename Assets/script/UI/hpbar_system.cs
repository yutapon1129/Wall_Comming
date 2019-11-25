using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpbar_system : MonoBehaviour
{
    public GameObject hpbar;
    public bool ber_delete = false;

    // Start is called before the first frame update
    void Start()
    {
        if (ber_delete == true)
        {
            hpbar = GameObject.Find("boss_hpbar");
            hpbar.GetComponent<boss_hpbar>().activator();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
