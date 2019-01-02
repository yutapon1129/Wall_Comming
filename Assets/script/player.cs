using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    public float speed = 10f; //歩くスピード
    private Rigidbody2D rigidbody2D;　//rigidbody習得
    private Animator anim;  //animator習得
    public float jumpPower = 700; //ジャンプ力
    public bool jumpbool = false;
    public LayerMask groundLayer; //Linecastで判定するLayer
    private bool isGrounded; //着地判定
    public GameObject cannon_object;
    bool jump = false;
    float intervalTime;

    public GameObject gateeffect;

    public Joystick joystick;

    bool isFalling;

    public int atk = 1;//攻撃力
    GameObject obj;
    public GameObject atk_aura, Player;

    void Start()
    {
        //コンポーネントをキャッシュ
        anim = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
<<<<<<< HEAD
        SceneManager.sceneLoaded += OnSceneLoaded;
=======
>>>>>>> 4f3955d8af792feb9e18b19e3ae1ed3a0a65bc91
    }

    private void Update()
    {
        //足元に地面があるか判定
        isGrounded = Physics2D.Linecast(
        transform.position - transform.up * 0.7f,
        transform.position - transform.up * 0.8f,
        groundLayer);

        Debug.DrawLine(
            transform.position,
            transform.position - transform.up * 0.8f,
            Color.red);

        if (isGrounded == true)
        {
            anim.SetBool("jump_bool", false);
            jump = false;
        }

        float velY = rigidbody2D.velocity.y;
        isFalling = velY < -0.1f ? true : false;

        //スペースキーを押し、
        if (Input.GetKeyDown("space"))
        {
            //着地していた時、
            if (isGrounded)
            {
                anim.SetBool("dash_bool", false);
                anim.SetBool("jump_bool", true);
                //着地判定をfalse
                isGrounded = false;
                //AddForceにて上方向へ力を加える
                //rigidbody2D.AddForce(Vector2.up * jumpPower);
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.y, 20);
            }

        }

        //if (isGrounded == true)
        //{
        //    anim.SetBool("jump_bool", false);
        //    jump = false;
        //}

        //float velY = rigidbody2D.velocity.y;
        //bool isFalling = velY < -0.1f ? true : false;

        //if (isFalling == false)
        //{
        //    if (Input.GetKeyUp("space"))
        //    {
        //        //キーを離したら落下するようにするもの
        //        rigidbody2D.velocity = new Vector3(0, 0, 0);
        //        jump = false;
        //    }
        //}


        //弾丸発射処理
        intervalTime += Time.deltaTime;
        if (Input.GetKeyDown("left ctrl"))
        {
            if (intervalTime >= 0.1f)
            {
                intervalTime = 0.0f;
                anim.SetTrigger("shot");
                cannon_object.GetComponent<cannon>().gun();
            }
        }
    }

    void FixedUpdate()
    {
        //左右入力
        //float x = Input.GetAxis("Horizontal");

        float x = joystick.Horizontal;

        //左右どちらかが入力されたら
        if (x != 0)
            {
                //入力方向へ移動
                rigidbody2D.velocity = new Vector2(x * speed, rigidbody2D.velocity.y);
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
                rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
                //Dash→Wait
                anim.SetBool("dash_bool", false);
            }
    }

    public void UIshot()
    {
        Debug.Log("shot");
        intervalTime = 0.0f;
        anim.SetTrigger("shot");
        cannon_object.GetComponent<cannon>().gun();
    }
    bool push = false;

    public void PushDown()
    {
        //着地していた時、
        if (isGrounded)
        {
            anim.SetBool("dash_bool", false);
            anim.SetBool("jump_bool", true);
            //着地判定をfalse
            isGrounded = false;
            //AddForceにて上方向へ力を加える
            //rigidbody2D.AddForce(Vector2.up * jumpPower);
             rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.y, 18);
        }
    }

    public void PushUp()
    {
        if (isFalling == false)
        {
            //キーを離したら落下するようにするもの
            rigidbody2D.velocity = new Vector3(0, 0, 0);
            jump = false;
        }
    }

    //攻撃力関係

    public void atkup()
    {
        atk = atk + 1;
        Debug.Log(atk);
        //Instantiate(atk_aura, this.transform.position, Quaternion.identity);
        obj= (GameObject)Instantiate(atk_aura, this.transform.position, Quaternion.identity);
        obj.transform.parent = Player.transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "gate")
        {
            Player.SetActive(false);
            Instantiate(gateeffect, this.transform.position, Quaternion.identity);
        }
    }
}

