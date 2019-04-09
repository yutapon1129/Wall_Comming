﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_R_Slime : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    public int speed = -3, x = 1;

    //体力関係
    public int HP;
    public GameObject player;
    public GameObject explosion;

    //カメラ関係
    private const string MAIN_CAMERA_TAG_NAME = "MainCamera";
    private bool _isRendered = false;

    //コルーチン関係
    private Renderer renderer;

    //攻撃関係
    public float timeOut;//攻撃頻度の時間
    private float timeElapsed;//時間計測変数格納用



    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        renderer = GetComponent<Renderer>();
        player = GameObject.Find("player");
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;//時間計測

        if (timeElapsed >= timeOut)//設定した時間になったら読み込み
        {
            StartCoroutine("attack");
            timeElapsed = 0.0f;//変数リセット用
        }
    }
    void FixedUpdate()
    {
        if (_isRendered)
        {
            rigidbody2D.velocity = new Vector2(speed, rigidbody2D.velocity.y);
        }

        if (gameObject.transform.position.y < Camera.main.transform.position.y - 8)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (_isRendered)
        {
            if (col.tag == "bullet")
            {

                int player_atk = player.GetComponent<player>().atk;
                HP = HP - player_atk;
                if (HP <= 0)
                {
                    Destroy(gameObject);
                    Instantiate(explosion, transform.position, transform.rotation);
                }
                StartCoroutine("Damage");
            }
            if (col.tag == "boss")
            {
                Destroy(gameObject);
                Instantiate(explosion, transform.position, transform.rotation);
            }

            if (col.tag == "ground" || col.tag == "enemy" || col.gameObject.tag == "trap")
            {

                speed = speed * -1;
                x = x * -1;
                transform.localScale = new Vector2(x, 1);
            }
        }
    }

    //Rendererがカメラに映ってる間に呼ばれ続ける
    void OnWillRenderObject()
    {
        //メインカメラに映った時だけ_isRenderedをtrue
        if (Camera.current.tag == MAIN_CAMERA_TAG_NAME)
        {
            _isRendered = true;
        }
    }
}
