using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W3_BackgroundMove : MonoBehaviour
{
    [SerializeField] GameObject Camera;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(Camera.transform.position.x, Camera.transform.position.y, -1);
    }
}
