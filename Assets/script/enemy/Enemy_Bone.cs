﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bone : MonoBehaviour
{

    Rigidbody2D rb;                      //rigidbody格納用
    int x = 1;                           //画像反転用
    [SerializeField] GameObject bone;    //飛ばす骨
    [SerializeField] int speed;          //移動速度

    private const string MAIN_CAMERA_TAG_NAME = "MainCamera";   //ﾒｲﾝｶﾒﾗ格納
    private bool _isRendered = false;                           //ｶﾒﾗ真偽

    public float timeOut;           //攻撃頻度の時間
    private float timeElapsed;      //時間計測変数格納用


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   //Rigidbody取得
    }

    void FixedUpdate()
    {
        if (_isRendered)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);

            timeElapsed += Time.deltaTime;//時間計測

            if (timeElapsed >= timeOut)//設定した時間になったら読み込み
            {
                StartCoroutine("Attack");
                timeElapsed = 0.0f;//変数リセット用
            }
        }

        if (gameObject.transform.position.y < Camera.main.transform.position.y - 8)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isRendered)
        {
            if (collision.tag == "ground" || collision.tag == "enemy" || collision.gameObject.tag == "trap")
            {
                speed = speed * -1;
                x = x * -1;
                transform.localScale = new Vector2(x, 1);
            }
        }
    }

    private IEnumerator Attack()
    {
        GameObject shot = Instantiate(bone, transform.position, transform.rotation) as GameObject; 
        yield return null;
        Bone s = shot.GetComponent<Bone>();
        yield return null;
        s.Create(transform.localScale.x);

        StopCoroutine("Attack");
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
