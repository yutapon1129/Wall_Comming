using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class boss : MonoBehaviour {

    Rigidbody2D rigidbody2D;
    public float speed = -3;
    public GameObject explosion;

    public int flag;

    //カメラ関係
    private const string MAIN_CAMERA_TAG_NAME = "MainCamera";
    private bool _isRendered = false;
    //体力関係
    public int HP;
    public GameObject player;

    public string name;

    public GameObject Rsystem;



    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        player = GameObject.Find("player");
    }

    void Update()
    {

    }
    void FixedUpdate()
    {
        //if (_isRendered)
        //{
            rigidbody2D.velocity = new Vector2(speed, rigidbody2D.velocity.y);
        //}

        if (gameObject.transform.position.y < Camera.main.transform.position.y - 8)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //if (_isRendered)
        //{
            // 体力関係
            if (col.tag == "bullet")
            {
                int player_atk = player.GetComponent<PlayerExtra>().atk;
                HP = HP - player_atk;
                if (HP <= 0)
                {
                    Rsystem = GameObject.Find("restart_bool");//restart_boolの取得
                    Destroy(Rsystem);                         //restart_boolの削除

                    this.gameObject.SetActive(false);
                    Instantiate(explosion, transform.position, transform.rotation);
                    FadeManager.Instance.LoadScene("select", 2.0f);
                    FlagManager.Instance.flags[flag] = true;
                }
            }
        //}
    }


   
    void OnWillRenderObject()
    {
        //メインカメラに映った時だけ_isRenderedをtrue
        if (Camera.current.tag == MAIN_CAMERA_TAG_NAME)
        {
            _isRendered = true;
        }
    }
}
