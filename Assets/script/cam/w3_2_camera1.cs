using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class w3_2_camera1 : MonoBehaviour
{
    // Start is called before the first frame update
    public CinemachineVirtualCamera vcamera;

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "player")
        {
            vcamera.Priority = 5;
        }

    }
}