using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_title : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float camera_L, camera_R;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        transform.position = new Vector3(player.transform.position.x, 0, -1);

        if (transform.position.x > camera_R)
        {
            transform.position = new Vector3(camera_R, 0, -1);
        }
        if (transform.position.x < camera_L)
        {
            transform.position = new Vector3(camera_L, 0, -1);
        }
    }
}
