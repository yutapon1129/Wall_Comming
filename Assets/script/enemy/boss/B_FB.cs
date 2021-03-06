﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_FB : MonoBehaviour
{
    private GameObject player;
    [SerializeField] float speed = 2.5f;
    public float Velocity_0, theta;
    Rigidbody2D rid2d;

    void Start()
    {
        ////player取得
        player = GameObject.Find("player");

        // バースト用弾の速度処理-----バースト弾のところに↓入れてね
        GetComponent<Rigidbody2D>().velocity = transform.up * speed;
        Destroy(gameObject, 30);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "ground")
        {
            Destroy(gameObject);
        }
    }
}
