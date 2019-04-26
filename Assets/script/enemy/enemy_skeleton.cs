using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Skeleton : MonoBehaviour
{

    Rigidbody2D rb;                 //rigidbody格納用
    public GameObject bone;         //飛ばす骨
    public int speed,               //敵の移動速度
               speed_box,           //ｺﾙｰﾁﾝ用
               x = 1;               //画像反転用

    private const string MAIN_CAMERA_TAG_NAME = "MainCamera";   //ﾒｲﾝｶﾒﾗ格納
    private bool _isRendered = false;                           //ｶﾒﾗ真偽

    public float timeOut;           //攻撃頻度の時間
    private float timeElapsed;      //時間計測変数格納用


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   //Rigidbody取得
    }



    void Update()
    {
        if (_isRendered)
        {
            
        }
    }
    void FixedUpdate()
    {
        if (_isRendered)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);

            timeElapsed += Time.timeScale;//時間計測
            Debug.Log(timeElapsed);

            if (timeElapsed >= timeOut)//設定した時間になったら読み込み
            {

                StartCoroutine("attack");
                timeElapsed = 0.0f;//変数リセット用
            }
        }

        if (gameObject.transform.position.y < Camera.main.transform.position.y - 8)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isRendered)
        {
            if (collision.tag == "ground" || collision.tag == "enemy" || collision.gameObject.tag == "trap")
            {
                speed = speed * -1;
                x = x * -1;
                transform.localScale = new Vector2(x, 1);
            }
        }
    }

    //private IEnumerator Attack()
    //{
    //    int count = 1;
    //    while (count > 0)
    //    {
    //        speed_box = speed;
    //        speed = 0;

    //        yield return new WaitForSeconds(1.0f);

    //        Instantiate(bone, transform.position, transform.rotation);

    //        yield return new WaitForSeconds(1.0f);

    //        speed = speed_box;
    //        Debug.Log("aaa");
    //        count--;
    //    }
    //}

    private IEnumerator attack()
    {
        int count = 6;
        while (count > 0)
        {
            //0.05秒待つ
            yield return new WaitForSeconds(0.05f);
            //元に戻す
            Instantiate(bone, transform.position, transform.rotation);
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
