using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall_del : MonoBehaviour
{

    public int flag;

    // Start is called before the first frame update
    void Start()
    {
        if(FlagManager.Instance.flags[flag] == true)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
