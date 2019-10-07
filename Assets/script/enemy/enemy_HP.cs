using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_HP : MonoBehaviour
{
    Rigidbody2D rb;                 //rigidbody格納用

    public int HP;                  //敵の体力
    private GameObject player;      //player格納用
    public GameObject death;        //敵の爆発ｴﾌｪｸﾄ
    private Renderer renderer;      //ｷｬﾗ画像詳細格納

    private const string MAIN_CAMERA_TAG_NAME = "MainCamera";   //ﾒｲﾝｶﾒﾗ格納
    private bool _isRendered = false;                           //ｶﾒﾗ真偽

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        renderer = GetComponent<Renderer>();
        player = GameObject.Find("player");
    }


    //接触ダメージ関係
    //新たに敵を作る際は子オブジェクトにTriggerの判定を付けること。
    //その際は上下を1ﾄﾞｯﾄ分開けること。
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isRendered)
        {
            //弾丸接触時
            if (collision.tag == "bullet")
            {
                int player_atk = player.GetComponent<PlayerExtra>().atk;
                Debug.Log(HP);
                HP = HP - player_atk;
                Debug.Log(HP);
                if (HP <= 0)
                {
                    Destroy(gameObject);
                    Instantiate(death, transform.position, transform.rotation);
                }
                StartCoroutine("Damage");
            }
            //ボス接触時
            if (collision.tag == "boss")
            {
                Destroy(gameObject);
                Instantiate(death, transform.position, transform.rotation);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //trap
        if (collision.gameObject.tag == "trap")
        {
            Destroy(gameObject);
            Instantiate(death, transform.position, transform.rotation);
        }
    }


    //被ダメージ処理　ただ点滅するだけ
    private IEnumerator Damage()
    {
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
