using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling_floor : MonoBehaviour
{
    Rigidbody2D rb;                     //rigidbody格納用
    private bool floor_bool;            //乗ってるか否か  
    private bool shake_bool = true;     //ゆらしたか否か
    [SerializeField] float speed;       //落下速度
    [SerializeField] float shaketime;   //揺れる時間
    [SerializeField] float shakewide;   //揺れる幅

    private Vector2 defaultposition;    //最初の位置
    private float timeElapsed;          //時間計測変数格納用
    [SerializeField] float revivaltime; //戻るまでの時間

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  //Rigidbody取得
        defaultposition = gameObject.transform.position;    //初期位置格納
    }

    void FixedUpdate()
    {
        if(floor_bool == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, speed);

            timeElapsed += Time.timeScale;//時間計測

            if (timeElapsed >= revivaltime)//設定した時間になったら読み込み
            {
                floor_bool = false;                     //落下中ではないので
                shake_bool = true;                      //揺れてないから
                transform.position = defaultposition;   //設置した箇所に戻す
                rb.velocity = Vector2.zero;             //加速度を初期化
                StartCoroutine(Flashing());             //点滅コルーチン実行

                timeElapsed = 0.0f; //計測リセット
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            if (shake_bool == true)
            {
                Invoke("StartFall", 2);
                StartCoroutine(DoShake());
            }
        }
    }

    void StartFall()
    {
        floor_bool = true;
    }

    private IEnumerator DoShake()   //乗った時に揺らす
    {
        shake_bool = false;     //一度だけ揺らす為

        var pos = transform.localPosition;

        var elapsed = 0f;

        while (elapsed < shaketime)
        {
            var x = pos.x + Random.Range(-1f, 1f) * shakewide;
            //var y = pos.y + Random.Range(-1f, 1f) * shakewide;        //y軸にもゆらす場合

            transform.localPosition = new Vector3(x, pos.y, pos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = pos;
    }

    private IEnumerator Flashing()    //床復活時の点滅用
    {
        foreach (Transform transform in gameObject.transform)
        {
            // Transformからゲームオブジェクト取得
            var child = transform.gameObject;

            //点滅
            int count = 6;
            while(count > 0)
            {
                child.gameObject.SetActive(false);
                yield return new WaitForSeconds(0.05f);
                child.gameObject.SetActive(true);
                yield return new WaitForSeconds(0.05f);
                count--;
            }
        }

        yield return null;

    }
}
