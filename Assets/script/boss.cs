using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class boss : MonoBehaviour {

    Rigidbody2D rigidbody2D;
    public int speed = -3, x = 1;
    public GameObject explosion;

    public int flag;

    //カメラ関係
    private const string MAIN_CAMERA_TAG_NAME = "MainCamera";
    private bool _isRendered = false;
    //体力関係
    public int HP;



    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }
    void FixedUpdate()
    {
        if (_isRendered)
        {
            rigidbody2D.velocity = new Vector2(speed, rigidbody2D.velocity.y);
        }

        if (gameObject.transform.position.y < Camera.main.transform.position.y - 8)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (_isRendered)
        {
            if (col.tag == "bullet")
            {
                HP = HP - 1;
                if (HP == 0)
                {
                    this.gameObject.SetActive(false);
                    Instantiate(explosion, transform.position, transform.rotation);
                    FadeManager.Instance.LoadScene("select", 2.0f);
                    FlagManager.Instance.flags[flag] = true;
                }
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
