using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bool_create : MonoBehaviour
{
    public GameObject system;

    // Start is called before the first frame update
    void Awake()
    {
        Instantiate(system);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
