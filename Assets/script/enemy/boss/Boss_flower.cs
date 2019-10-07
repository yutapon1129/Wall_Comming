using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_flower : MonoBehaviour
{
    // 出現させる弾
    [SerializeField] GameObject Boss_FB;
    // 弾を出現させるまでの時間
    [SerializeField] float bullet_Next_Time;
    // 出現させる弾の数
    [SerializeField] int maxNumOfbullets;
    // 出現している弾の総数
    private int numOfbullet;
    // 待ち時間計測フィールド
    private float wait_Time;


    // Start is called before the first frame update
    void Start()
    {
        numOfbullet = 0;
        wait_Time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //// 出現する弾の最大数を超えていたら撃たない
        //if(numOfbullet >= maxNumOfbullets)
        //{
        //    return;
        //}
        // 経過時間を足す
        wait_Time += Time.timeScale;

        // 経過時間が経ったら
        if(wait_Time > bullet_Next_Time)
        {
            wait_Time = 0f;
            AppearBullet();
        }

    }

    void AppearBullet()
    {
        Instantiate(Boss_FB, transform.position, Quaternion.Euler(0f, 0f, 0f));

        numOfbullet++;
        
    }
}
