using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_slug : MonoBehaviour
{
    Rigidbody2D rb;                     //rigidbody格納用
    public float speed,                 //敵の移動速度
                 x = 1;                 //画像反転用

    private const string MAIN_CAMERA_TAG_NAME = "MainCamera";   //ﾒｲﾝｶﾒﾗ格納
    private bool _isRendered = false;                           //ｶﾒﾗ真偽

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();  //Rigidbody取得
    }

    void FixedUpdate()
    {
        if (_isRendered)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }

        //奈落へ落ちたら死ぬ用
        if (gameObject.transform.position.y < Camera.main.transform.position.y - 8)
        {
            Destroy(gameObject);
        }

        Debug.Log(_isRendered);
    }

    private void OnTriggerEnter2D(Collider2D collision)
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
