using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_HP : MonoBehaviour
{
    Rigidbody2D rb;                 //rigidbody格納用

    public int HP;                  //敵の体力
    private GameObject player;      //player格納用
    public GameObject explosion;    //敵の爆発ｴﾌｪｸﾄ
    private Renderer renderer;      //ｷｬﾗ画像詳細格納

    private const string MAIN_CAMERA_TAG_NAME = "MainCamera";   //ﾒｲﾝｶﾒﾗ格納
    private bool _isRendered = false;                           //ｶﾒﾗ真偽

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        renderer = GetComponent<Renderer>();
        player = GameObject.Find("player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isRendered)
        {
            if (collision.tag == "bullet")
            {

                int player_atk = player.GetComponent<PlayerExtra>().atk;
                HP = HP - player_atk;
                if (HP <= 0)
                {
                    Destroy(gameObject);
                    Instantiate(explosion, transform.position, transform.rotation);
                }
                StartCoroutine("Damage");
            }
            if (collision.tag == "boss")
            {
                Destroy(gameObject);
                Instantiate(explosion, transform.position, transform.rotation);
            }
        }
    }

    private IEnumerator Damage()
    {
        //while文を10回ループ
        int count = 6;
        while (count > 0)
        {
            //透明にする
            renderer.material.color = new Color(1, 1, 1, 0);
            //0.05秒待つ
            yield return new WaitForSeconds(0.05f);
            //元に戻す
            renderer.material.color = new Color(1, 1, 1, 1);
            //0.05秒待つ
            yield return new WaitForSeconds(0.05f);
            count--;
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
