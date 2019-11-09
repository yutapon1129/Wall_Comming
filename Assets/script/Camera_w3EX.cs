using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_w3EX : MonoBehaviour
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
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1.5f, -1);
    }
}
