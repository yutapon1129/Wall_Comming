using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bee : MonoBehaviour
{
    Rigidbody2D rb;                 //rigidbody格納用

    private const string MAIN_CAMERA_TAG_NAME = "MainCamera";   //ﾒｲﾝｶﾒﾗ格納
    private bool _isRendered = false;                           //ｶﾒﾗ真偽

    [SerializeField] int speed,         //移動速度        
                         high,          //移動高さ
                         speed_updown,  //上下移動の速度
                         x = 1;         //画像反転用

    [SerializeField] bool Wave;         //上下に動くか否か


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  //Rigidbody取得
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_isRendered)
        {
            if (Wave == true)
            {
                rb.velocity = new Vector2(speed, high * Mathf.Sin(Time.time * 10));
            }
            else
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }

            Debug.Log(Mathf.PingPong(Time.time, 3));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isRendered)
        {
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
