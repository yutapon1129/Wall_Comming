using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug_Mode : MonoBehaviour
{
    int i;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            for (i = 0; i < 30; i++)
            {
                FlagManager.Instance.flags[i] = true;
            }
        }
    }
}
