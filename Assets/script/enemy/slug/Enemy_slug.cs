using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_slug : MonoBehaviour
{
    Rigidbody2D rb;                     //rigidbody格納用
   [SerializeField]float speed,                 //敵の移動速度
                         x = 1;                 //画像反転用

    const string MAIN_CAMERA_TAG_NAME = "MainCamera";   //ﾒｲﾝｶﾒﾗ格納
    bool _isRendered = false;                           //ｶﾒﾗ真偽

    [SerializeField]GameObject slug;                            //自分自身格納用
    [SerializeField]int MyHP, MyHP_before;                      //自身の体力
    bool speed_bool = true;                                     //速度上昇用


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  //Rigidbody取得
        MyHP_before = slug.GetComponent<Enemy_Health>().HP;
    }

    void Update()
    {
        //奈落へ落ちたら死ぬ用
        if (gameObject.transform.position.y < Camera.main.transform.position.y - 8)
        {
            Destroy(gameObject);
        }

        MyHP = slug.GetComponent<Enemy_Health>().HP;    //自分自身の体力を習得

        if (speed_bool == true)
        {
            if (MyHP_before / 2 >= MyHP)
            {
                speed = speed * 2;
                speed_bool = false;
            }
        }
    }
    void FixedUpdate()
    {
        if (_isRendered)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isRendered)
        {
            //地面かトラップにぶつかったら折り返す
            if (collision.tag == "ground" || collision.gameObject.tag == "trap")
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
