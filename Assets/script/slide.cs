using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slide : MonoBehaviour
{
    public bool move;
    public float speed, plase;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (move == true)
        {
            transform.Translate(-speed, 0, 0);
            if (transform.position.x < -plase)
            {
                transform.position = new Vector3(plase, 0, 0);
            }
        }
    }
}
