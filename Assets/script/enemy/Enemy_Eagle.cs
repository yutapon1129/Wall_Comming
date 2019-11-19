using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Eagle : MonoBehaviour
{
    Rigidbody2D rb;                 //rigidbody格納用

    private const string MAIN_CAMERA_TAG_NAME = "MainCamera";   //ﾒｲﾝｶﾒﾗ格納
    private bool _isRendered = false;                           //ｶﾒﾗ真偽

    [SerializeField] int speed;         //移動速度


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
            //直線で動く
            rb.velocity = new Vector2(speed, rb.velocity.y);
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

