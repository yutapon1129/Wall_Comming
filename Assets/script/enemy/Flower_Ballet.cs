using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower_Ballet : MonoBehaviour
{
    private GameObject player;
    GameObject obj;
    private int speed = 40;

    public GameObject bul;       // 弾
    // 1秒毎に弾を発射するためのもの
    private float targetTime = 1.0f;
    private float currentTime = 0;

    private const string MAIN_CAMERA_TAG_NAME = "MainCamera";   //ﾒｲﾝｶﾒﾗ格納
    private bool _isRendered = false;

    public float timeOut;           //攻撃頻度の時間
    private float timeElapsed;      //時間計測変数格納用//ｶﾒﾗ真偽

    void Start()
    {
        
    }

    //void Update()
    //{
    //    if (_isRendered)
    //    {
    //        currentTime += Time.deltaTime;

    //        if (targetTime < currentTime)
    //        {
    //            Debug.Log("はじまり");
                
    //            // 敵の座標を変数posに保存
    //            var pos = gameObject.transform.position;
    //            // 弾のプレハブを作成
    //            var t = Instantiate(bul) as GameObject;
    //            // 弾のプレハブの位置を敵の位置にする
    //            t.transform.position = pos;

    //            // 敵からプレイヤーに向かうベクトルを作る
    //            // プレイヤーの位置から敵の位置(弾の位置)を引く
    //            Vector2 vec = obj.transform.position - pos;
    //            // 弾のRigidBody2Dコンポーネントのvelocityに先ほど求めたベクトルを入れて力を加える
    //            t.GetComponent<Rigidbody2D>().velocity = vec;
    //            Debug.Log("hassya");
    //            currentTime = 0;

    //        }
    //    }
    //}

    void FixedUpdate()
    {
        if (_isRendered)
        {
            timeElapsed += Time.timeScale;//時間計測


            if (timeElapsed >= timeOut)//設定した時間になったら読み込み
            {
                Debug.Log("はじまり");

                // 敵の座標を変数posに保存
                var pos = gameObject.transform.position;
                // 弾のプレハブを作成
                var t = Instantiate(bul) as GameObject;
                // 弾のプレハブの位置を敵の位置にする
                t.transform.position = pos;

                // 敵からプレイヤーに向かうベクトルを作る
                // プレイヤーの位置から敵の位置(弾の位置)を引く
                Vector2 vec = obj.transform.position - pos;
                // 弾のRigidBody2Dコンポーネントのvelocityに先ほど求めたベクトルを入れて力を加える
                t.GetComponent<Rigidbody2D>().velocity = vec;
                Debug.Log("hassya");
                // currentTime = 0;

                timeElapsed = 0.0f;//変数リセット用
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
