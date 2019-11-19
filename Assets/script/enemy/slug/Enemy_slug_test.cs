using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_slug_test : MonoBehaviour
{
    Rigidbody2D rb;                     //rigidbody格納用
    [SerializeField] float speed;         //敵の移動速度

    const string MAIN_CAMERA_TAG_NAME = "MainCamera";   //ﾒｲﾝｶﾒﾗ格納
    bool _isRendered = false;                           //ｶﾒﾗ真偽

    [SerializeField] GameObject slug;                            //自分自身格納用
    [SerializeField] int MyHP, MyHP_before;                      //自身の体力
    bool speed_bool = true;                                     //速度上昇用

    private Vector3 touchStartPos;
    private Vector3 touchEndPos;
    private int direction = 4;
    public Vector2 SPD = new Vector2(0.05f, 0.05f);
    int dire = 0;

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

        Debug.Log(transform.eulerAngles.z);

        if (transform.localEulerAngles.z == 0)
        {
            dire = 0;
        }
        else if (transform.localEulerAngles.z == 90)
        {
            dire = 1;
        }
        else if (transform.localEulerAngles.z == 180)
        {
            dire = 2;
        }
        else if (transform.localEulerAngles.z == 270)
        {
            dire = 3;
        }

    }
    
    void FixedUpdate()
    {
        if (_isRendered)
        {
            switch (dire)
            {
                case 0:
                    rb.velocity = new Vector2(-speed, 0);
                    Debug.Log("case0");
                    break;

                case 1:
                    rb.velocity = new Vector2(0, -speed);
                    Debug.Log("case1");
                    break;

                case 2:
                    rb.velocity = new Vector2(speed, 0);
                    Debug.Log("case2");
                    break;

                case 3:
                    rb.velocity = new Vector2(0, speed);
                    Debug.Log("case3");
                    break;

            }
        }
    }

    // Enemy_slug_test_turn1(スラグテストの後ろ足)
    public void turn_right()
    {
        transform.Rotate(new Vector3(0, 0, 90));
    }
    // Enemy_slug_test_turn2(スラグテストの頭のところ)
    public void turn_left()
    {
        transform.Rotate(new Vector3(0, 0, -90));
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
