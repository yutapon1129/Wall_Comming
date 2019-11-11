using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_w3EX : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject mine;
    [SerializeField] float camera_Up, camera_Down;
    [SerializeField] float camera_L, camera_R;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("player");
        mine = this.gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1.5f, -1);

        if (transform.position.x > camera_R)
        {
            transform.position = new Vector3(camera_R, mine.transform.position.y, -1);
        }

        if (transform.position.x < camera_L)
        {
            transform.position = new Vector3(camera_L, mine.transform.position.y, -1);
        }

        if (transform.position.y < camera_Down)
        {
            transform.position = new Vector3(mine.transform.position.x, camera_Down, -1);
        }

        if(transform.position.y > camera_Up)
        {
            transform.position = new Vector3(mine.transform.position.x, camera_Up, -1);
        }
    }
}
