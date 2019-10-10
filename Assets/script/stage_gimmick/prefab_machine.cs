using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prefab_machine : MonoBehaviour
{
    [SerializeField] GameObject floor;          //生み出す床
    [SerializeField] float speed, deletetime;   //床の移動速度と消す時間
    [SerializeField] float delay;               //最初の床を出すまでの時間

    public float timeOut;           //生成頻度
    private float timeElapsed;      //時間計測変数格納用
    private bool floor_bool;        //遅延処理用

    void Start()
    {
        Invoke("first_floor", delay);
        timeElapsed = timeOut;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (floor_bool)
        {
            timeElapsed += Time.timeScale;//時間計測

            if (timeElapsed >= timeOut)//設定した時間になったら読み込み
            {
                GameObject a = Instantiate(floor, transform.position, transform.rotation) as GameObject;

                move_instant A = a.GetComponent<move_instant>();
                A.Create(speed, deletetime);

                timeElapsed = 0.0f;//変数リセット用
            }
        }
    }

    void first_floor()
    {
        floor_bool = true;
    }
}
