using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy_Flower : MonoBehaviour
{
    Rigidbody2D rb;                 // rigidbody格納用
    public GameObject bullet;       // 飛ばす弾丸
    public int x = 1;               // 画像反転用

    public static bool In = true;      // 索敵範囲内かどうか
    bool bp1 = false, bp2 = false, bp3 = false, shot = true;    // 弾丸が何個でたか、また初弾は撃ったか
    int spd;        // 弾丸の移動速度
    Vector3 position;       // 花の位置
    public GameObject danmaku;      // 複製したい弾丸
    static Vector2 p1;              // 移動位置その１
    static Vector2 p2;              // 移動位置その２
    static Vector2 p3;              // 移動位置その３
    GameObject a, b, c;             // f複製した弾丸のスペース

    private const string MAIN_CAMERA_TAG_NAME = "MainCamera";   //ﾒｲﾝｶﾒﾗ格納
    private bool _isRendered = false;

    public float timeOut;           //攻撃頻度の時間
    private float timeElapsed;      //時間計測変数格納用//ｶﾒﾗ真偽


    // Start is called before the first frame update
    void Start()
    {
        spd = 1;
        position = transform.position;
        p1 = new Vector2(position.x, position.y + 1f);
        p2 = new Vector2(position.x - 0.7f, position.y + 0.65f);
        p3 = new Vector2(position.x + 0.7f, position.y + 0.65f);
    }

    /*void LookAt2D(GameObject d, Vector2 point)
    {
        float dx = point.x;
        float dy = point.y;
        float rad = (Mathf.Atan2(dy, dx) * 180 / Mathf.PI) - 90;
        d.transform.rotation = Quaternion.Euler(0, 0, rad);
    }*/

    // Update is called once per frame
    void Update()
    {
        if (_isRendered)
        {
            // playerが索敵範囲内に入ってきてから、まだ１発も撃ってないときF_shotを呼ぶ
            if (In && shot)
            {
                StartCoroutine("F_shot");
                Debug.Log("FFFF");
            }
            // 弾丸が生成されたかどうかを調べて、生成されたら、それぞれ移動させる
            if (a != null && bp1)
            {
                a.transform.Translate(p1 * spd * Time.deltaTime);
                StartCoroutine("Stop"); // 止めるための関数
                Debug.Log("BBBB");
            }
            if (a != null && b != null && bp2)
            {
                a.transform.Translate(p2 * spd * Time.deltaTime);
                b.transform.Translate(p2 * spd * Time.deltaTime);
                StartCoroutine("Stop");
            }
            if (a != null && b != null && c != null && bp3)
            {
                a.transform.Translate(p1 * spd * Time.deltaTime);
                c.transform.Translate(p2 * spd * Time.deltaTime);
                b.transform.Translate(p3 * spd * Time.deltaTime);
                StartCoroutine("Stop");
            }     
            
        }

    }
    IEnumerator F_shot()
    {
        
        Vector3 diff = (danmaku.gameObject.transform.position - this.transform.position);
        this.transform.rotation = Quaternion.FromToRotation(Vector3.up, diff);
        Enemy_Flower obj = new Enemy_Flower();
        Debug.Log("F_Shot");
        // これから初弾を撃つのでshotをfalseにする。
        if (shot)
        {
            shot = false;
            Debug.Log("false");
        }
        // 移動に１秒かかるので１秒たったらサインを出す。
        if (Random.Range(0, 10) >= 5) // 1発
        {
            spd = 1;
            a = Instantiate(danmaku, transform.position, Quaternion.Euler(0, 0, 0));
            a.transform.rotation = Quaternion.FromToRotation(Vector3.up, p1);
            bp1 = true;
            yield return new WaitForSeconds(1f);
            a.SendMessage("kill", 0, SendMessageOptions.DontRequireReceiver);
            Debug.Log("one");
            F_shot();
            
        }
        else if (Random.Range(0, 10) >= 3)       // ２発
        {
            spd = 1;
            a = Instantiate(danmaku, position, Quaternion.Euler(0, 0, 0));
            b = Instantiate(danmaku, position, Quaternion.Euler(0, 0, 0));
            a.transform.rotation = Quaternion.FromToRotation(Vector3.up, p2);
            b.transform.rotation = Quaternion.FromToRotation(Vector3.up, p3);
            bp2 = true;
            yield return new WaitForSeconds(1f);
            a.SendMessage("kill", 0, SendMessageOptions.DontRequireReceiver);
            b.SendMessage("kill", 0, SendMessageOptions.DontRequireReceiver);
            yield return new WaitForSeconds(5f);
            Debug.Log("two");
            F_shot();
        }
        else if (Random.Range(0, 10) >= 2)       // ３発
        {
            spd = 1;
            a = Instantiate(danmaku, position, Quaternion.Euler(0, 0, 0));
            b = Instantiate(danmaku, position, Quaternion.Euler(0, 0, 0));
            c = Instantiate(danmaku, position, Quaternion.Euler(0, 0, 0));
            a.transform.LookAt(p1);
            c.transform.LookAt(p2);
            b.transform.LookAt(p3);
            bp3 = true;
            yield return new WaitForSeconds(1f);
            a.SendMessage("kill", 0, SendMessageOptions.DontRequireReceiver);
            b.SendMessage("kill", 0, SendMessageOptions.DontRequireReceiver);
            c.SendMessage("kill", 0, SendMessageOptions.DontRequireReceiver);
            yield return new WaitForSeconds(5f);
            Debug.Log("three");
            F_shot();
        }
        else   // 0発
        {
            yield return new WaitForSeconds(3f);
            F_shot();
            Debug.Log("Stop");
        }
    }
    IEnumerator Stop()
    {
        yield return new WaitForSeconds(1f); // 移動に１秒かかるので、１秒待つ
        spd = 0;        // 止める
        // 撃ったかどうかをfalseにする
        bp1 = false;
        bp2 = false;
        bp3 = false;

        Debug.Log("Stopped");
    }
    


    /*private void StartCoroutine(IEnumerable enumerable)
    {
        throw new NotImplementedException();
    }*/

    void FixedUpdate()
    {
        if (_isRendered)
        {
            timeElapsed += Time.timeScale;//時間計測

            if (timeElapsed >= timeOut)//設定した時間になったら読み込み
            {
                timeElapsed = 0.0f;//変数リセット用
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isRendered)
        {

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

