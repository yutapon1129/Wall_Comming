using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// PC版用の挙動プログラム


public class Debug_moving : MonoBehaviour
{

    private Rigidbody2D rb;         //rigidbody格納用
    private Animator anim;          //Playerのanimator格納用


    [SerializeField] float JumpForce;         //ジャンプ力
    [SerializeField] float speed;             //歩くスピード

    
    [SerializeField] Transform feetPos;       //地面判定用オブジェクト
    [SerializeField] float checkRadius;       //検知範囲の半径
    [SerializeField] LayerMask whatIsGround;  //地面の種類
    private bool isGrounded;                  //地面判定

    private float jumpTimeCounter;      //長押しジャンプの長さ
    [SerializeField] float jumpTime;    //jumpTimeCounterへの格納用
    private bool isJumping;             //ジャンプ判定
    private bool now = false;           //ugui用 長押ししてるか否か

    [SerializeField] float upG;     //上昇中の重力
    [SerializeField] float downG;   //下降中の重力
    float x;                        //キーボード移動用
    bool test = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   //Rigitbody取得
        anim = GetComponent<Animator>();    //Animator取得
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //float x = Input.GetAxis("Horizontal");

        if (rb.velocity.x >= 10)
        {
            rb.velocity = new Vector2(10, rb.velocity.y);
        }
        if (rb.velocity.x <= -10)
        {
            rb.velocity = new Vector2(-10, rb.velocity.y);
        }

        //左右どちらかが入力されたら
        if (x != 0)
        {
            //入力方向へ移動
            if (x > 0)
            {
                // 右移動
                transform.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 10);
                if (rb.velocity.x <= -5)
                {
                    transform.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 700);
                }
            }

            if (x < 0)
            {
                // 左移動
                transform.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 10);
                if (rb.velocity.x >= 5)
                {
                    transform.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 700);
                }
            }

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
        //左右入力してない場合
        else
        {
            //左側に移動していたら右へ力を与える
            if (rb.velocity.x < -1)
            {
                Debug.Log("右の力");
                transform.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 50);
            }
            //右側に移動していたら右へ力を与える
            if (rb.velocity.x > 1)
            {
                Debug.Log("左の力");
                transform.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 50);
            }
            //左右の力が0に近くなったら0にする
            if ((rb.velocity.x <= 1) && (rb.velocity.x >= -1))
            {
                Debug.Log("力を打ち消す");
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
            //Dash→Wait
            anim.SetBool("dash_bool", false);
        }



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
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            test = true;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            test = true;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            test = false;
            x = 0;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            test = false;
            x = 0;
        }

        if(test == true)
        {
            x = Input.GetAxis("Horizontal");
        }


        //if (Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    x = 1;
        //}
        //if (Input.GetKeyUp(KeyCode.RightArrow))
        //{
        //    x = 0;
        //}

        //if (Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    x = -1;
        //}
        //if (Input.GetKeyUp(KeyCode.LeftArrow))
        //{
        //    x = 0;
        //}

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
