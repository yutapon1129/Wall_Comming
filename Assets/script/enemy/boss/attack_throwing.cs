using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack_throwing : MonoBehaviour
{
    public GameObject item; //投げるｵﾌﾞｼﾞｪｸﾄ

    public float timeOut;           //攻撃頻度の時間
    private float timeElapsed;      //時間計測変数格納用

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.timeScale;//時間計測
        Debug.Log(timeElapsed);
        if (timeElapsed >= timeOut)//設定した時間になったら読み込み
        {
            Instantiate(item, transform.position, transform.rotation);
            timeElapsed = 0.0f;//変数リセット用
        }
    }
}
