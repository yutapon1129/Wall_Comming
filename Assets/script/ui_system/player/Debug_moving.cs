using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//これはテストプレイやデバッグをする際にPCのキーボードで
//プレイヤーを扱えるようにするものです。

//ビルドする際は　”必ず”　外してください。

//尚、左右移動はマウスでバーチャルスティック弄ってください。
//（左右移動までキーボード対応するのめんどくさいから。どうせ消すし。）


public class Debug_moving : MonoBehaviour
{

    private Rigidbody2D rb;         //rigidbody格納用
    private Animator anim;          //Playerのanimator格納用


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

    [SerializeField] float upG,downG;   //上昇中と下降中の重力

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   //Rigitbody取得
        anim = GetComponent<Animator>();    //Animator取得
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            now = false;
        }


        if (now == true && isJumping == true)
        {
            
            if (jumpTimeCounter > 0)
            {
                anim.SetBool("jump_bool", true);
                rb.velocity = new Vector2(rb.velocity.x, JumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //着地していた時、
            if (isGrounded)
            {
                if (isGrounded == true)
                {
                    anim.SetBool("dash_bool", false);
                    isJumping = true;
                    jumpTimeCounter = jumpTime;
                }
                now = true;
            }
        }
        //地面接触判定
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        
        if (isGrounded)
        {
            anim.SetBool("jump_bool", false);
        }



        if (rb.velocity.y > 0.0f && Input.GetKey(KeyCode.Space))
        {
            rb.gravityScale = upG;
        }
        else
        {
            rb.gravityScale = downG;
        }
    }
}
