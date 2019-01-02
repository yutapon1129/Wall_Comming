using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_title : MonoBehaviour
{
    public GameObject player;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        transform.position = new Vector3(player.transform.position.x, 0, -100);

        if (transform.position.x > 0)
        {
            transform.position = new Vector3(0, 0, -100);
        }
        if (transform.position.x < -100)
        {
            transform.position = new Vector3(-100, 0, -100);
        }
    }
}
