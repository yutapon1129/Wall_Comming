using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_ground : MonoBehaviour
{
    private Vector3 initialPosition;
    public float speed;
    public bool MoveDirection;

    // Use this for initialization
    void Start()
    {
        initialPosition = transform.position;
    }

    void FixedUpdate()
    {
        if (MoveDirection == true)
        {
            transform.position = new Vector3(Mathf.Sin(Time.time) * speed + initialPosition.x, initialPosition.y, initialPosition.z);
        }
        else
        {
            transform.position = new Vector3(initialPosition.x, Mathf.Sin(Time.time) * speed + initialPosition.y, initialPosition.z);
        }
    }

    
}
