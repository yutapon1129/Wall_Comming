﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_turn : MonoBehaviour {

    Rigidbody2D rigidbody2D;
    public int speed = -3, x = 1;

    //体力関係
    public int HP;
    public GameObject explosion;
    public GameObject player;

    //カメラ関係
    private const string MAIN_CAMERA_TAG_NAME = "MainCamera";
    private bool _isRendered = false;

    //ターン関係
    bool RL = true;

    //コルーチン関係
    private Renderer renderer;


    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        renderer = GetComponent<Renderer>();
        player = GameObject.Find("player");
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

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ground" || collision.gameObject.tag == "move")
        {
            if (RL == true)
            {
                if (speed < 1)
                {
                    x = x * -1;
                    transform.localScale = new Vector3(x, 1, 0);
                    speed = speed * -1;
                    RL = false;
                    Debug.Log(RL);
                }
            }
            else
            {
                x = x * -1;
                transform.localScale = new Vector3(x, 1, 0);
                speed = speed * -1;
                RL = true;
                Debug.Log(RL);

            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (_isRendered)
        {
            if (col.tag == "bullet")
            {
                int player_atk = player.GetComponent<PlayerExtra>().atk;
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

            if (col.tag == "enemy" || col.gameObject.tag == "trap")//col.tag == "ground"
            {

                speed = speed * -1;
                x = x * -1;
                transform.localScale = new Vector2(x, 1);
            }
        }
    }

    IEnumerator Damage()
    {
        //while文を10回ループ
        int count = 6;
        while (count > 0)
        {
            //透明にする
            renderer.material.color = new Color(1, 1, 1, 0);
            //0.05秒待つ
            yield return new WaitForSeconds(0.05f);
            //元に戻す
            renderer.material.color = new Color(1, 1, 1, 1);
            //0.05秒待つ
            yield return new WaitForSeconds(0.05f);
            count--;
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
