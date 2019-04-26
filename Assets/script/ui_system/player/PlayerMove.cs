using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;         //rigidbody格納用
    private Animator anim;          //Playerのanimator格納用
    public Joystick joystick;       //JoyStick格納用

    public float JumpForce;         //ジャンプ力
    public float speed;             //歩くスピード
    private float intervalTime;     //弾丸連射速度

    private bool isGrounded;        //地面判定
    public Transform feetPos;       //地面判定用オブジェクト
    public float checkRadius;       //検知範囲の半径 
    public LayerMask whatIsGround;  //地面の種類

    private float jumpTimeCounter;  //長押しジャンプの長さ
    public float jumpTime;          //jumpTimeCounterへの格納用
    private bool isJumping;         //空中判定
    private bool now = false;       //ugui用 長押ししてるか否か



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   //Rigitbody取得
        anim = GetComponent<Animator>();    //Animator取得
    }

    private void FixedUpdate()
    {
        float x = joystick.Horizontal;

        //左右どちらかが入力されたら
        if (x != 0)
        {
            //入力方向へ移動
            rb.velocity = new Vector2(x * speed, rb.velocity.y);
            //localScale.xを-1にすると画像が反転する
            if (x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 0);
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 0);
            }
            anim.SetBool("dash_bool", true);
        }
        //左も右も入力していなかったら
        else
        {
            //横移動の速度を0にしてピタッと止まるようにする
            rb.velocity = new Vector2(0, rb.velocity.y);
            //Dash→Wait
            anim.SetBool("dash_bool", false);
        }
    }
    private void Update()
    {
        //地面接触判定
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        //ジャンプ処理
        //if (isGrounded == true && now == true)
        //{
        //    isJumping = true;
        //    jumpTimeCounter = jumpTime;
        //    rb.velocity = Vector2.up * JumpForce;
        //}

        if (now == true && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * JumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }


        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }

        if (isGrounded)
        {
            anim.SetBool("jump_bool", false);
        }
    }

    public void PushDown()
    {
        //着地していた時、
        if (isGrounded)
        {
            anim.SetBool("dash_bool", false);
            anim.SetBool("jump_bool", true);
            if (isGrounded == true)
            {
                isJumping = true;
                jumpTimeCounter = jumpTime;
                //rb.velocity = Vector2.up * JumpForce;
            }
            now = true;
        }
    }

    public void PushUp()
    {
        now = false;
    }

}