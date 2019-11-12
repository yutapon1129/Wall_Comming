using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W3_BackgroundMove : MonoBehaviour
{
    [SerializeField] GameObject Camera;     // メインカメラ格納

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0, Camera.transform.position.y, -1);   // y軸のみカメラ追従するように
    }
}
