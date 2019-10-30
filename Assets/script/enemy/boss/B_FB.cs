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

        //var pos = gameObject.transform.position;
        //Vector2 vec = player.transform.position - pos;

        // Rigidbody取得
        rid2d = GetComponent<Rigidbody2D>();
        // 角度を考慮して弾の速度計算
        Vector2 bulletV = rid2d.velocity;
        bulletV.x = Velocity_0 * Mathf.Cos(theta);
        bulletV.y = Velocity_0 * Mathf.Sin(theta);
        rid2d.velocity = bulletV;

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
