using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_R_Slime : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    [SerializeField] int speed = -3, x = 1;
    [SerializeField] GameObject player;

    //カメラ関係
    private const string MAIN_CAMERA_TAG_NAME = "MainCamera";
    private bool _isRendered = false;


    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        player = GameObject.Find("player");
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

    public void turn()
    {
        speed = speed * -1;
        x = x * -1;
        transform.localScale = new Vector2(x, 1);

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
