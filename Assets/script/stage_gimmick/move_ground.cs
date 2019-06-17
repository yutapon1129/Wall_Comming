using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_ground : MonoBehaviour
{
    private Vector3 initialPosition;

    // Use this for initialization
    void Start()
    {
        initialPosition = transform.position;
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(Mathf.Sin(Time.time) * 2.0f + initialPosition.x, initialPosition.y, initialPosition.z);
        //X座標のみ横移動
        //rb.MovePosition(new Vector2(defaultpass.x + Mathf.PingPong(Time.time, 3), defaultpass.y));
    }

    
}
