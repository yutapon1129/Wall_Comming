using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy_Flower : MonoBehaviour
{
    private const string MAIN_CAMERA_TAG_NAME = "MainCamera";   //ﾒｲﾝｶﾒﾗ格納
    private bool _isRendered = false;

    public float timeOut;           //攻撃頻度の時間
    private float timeElapsed;      //時間計測変数格納用//ｶﾒﾗ真偽

    [SerializeField] GameObject Flower_Cannon;      // 発射口格納用

    void FixedUpdate()
    {
        if (_isRendered)
        {
            timeElapsed += Time.timeScale;//時間計測

            if (timeElapsed >= timeOut)//設定した時間になったら読み込み
            {
                Flower_Cannon.GetComponent<Flower_Ballet>().shot();

                timeElapsed = 0.0f;//変数リセット用
            }


            if (Flower_Cannon.transform.eulerAngles.z > 0 && 180 > Flower_Cannon.transform.eulerAngles.z)
            {
                transform.localScale = new Vector2(1, 1);
            }
            else
            {
                transform.localScale = new Vector2(-1, 1);
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

