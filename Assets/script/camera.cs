﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour {

    public GameObject player;

    // Use this for initialization
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
    void Start () {
        player = GameObject.Find("player");
        Debug.Log("aaa");
=======
    void Start ()
    {
        player = GameObject.Find("player");    
>>>>>>> 4f3955d8af792feb9e18b19e3ae1ed3a0a65bc91
    }
=======
    void Start () {
        player = GameObject.Find("player");
	}
>>>>>>> parent of 08fee75... uiload完成
=======
    void Start () {
        player = GameObject.Find("player");
	}
>>>>>>> parent of 08fee75... uiload完成
	
	// Update is called once per frame
	void FixedUpdate () {

        transform.position = new Vector3(player.transform.position.x, 0, -100);

        if (transform.position.x < 0)
        {
            transform.position = new Vector3(0, 0, -100);
        }
        if (transform.position.x > 200)
        {
            transform.position = new Vector3(200, 0, -100);
        }
    }
}
