using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_flower : MonoBehaviour
{
    // 出現させる弾
    [SerializeField] GameObject Boss_FB, obj;
    //// 出現させるバースト弾
    //[SerializeField] GameObject Boss_Barst_Bullet;
    //// 出現させる3Way弾
    //[SerializeField] GameObject Boss_ThreeWay_Bullet;
    // 弾を出現させるまでの時間
    [SerializeField] float bullet_Next_Time;
    // 出現させる弾の数
    [SerializeField] int maxNumOfbullets;
    // 出現している弾の総数
    private int numOfbullet;
    // 待ち時間計測フィールド
    private float wait_Time;
    // バースト射撃の待ち時間計測
    public int burst_Delay = 0;

    public int count = 0;

    public float _velocity_0, Degree, n_way;
    float _theta;
    float PI = Mathf.PI;
    public float bulletInterval;    // 1発ごとの時間差(ミリ秒)
    public float shotInterval;      // 次の弾幕を出すまでの時間(秒)

    public GameObject[] barrage_shot;

    public bool barrage; // 弾幕モードになる


    // Start is called before the first frame update
    void Start()
    {
        numOfbullet = 0;
        wait_Time = 0f;
        obj = GameObject.Find("player");
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

        // LookAt2D(obj);

        // 経過時間が経ったら
        if (wait_Time > bullet_Next_Time)
        {
            wait_Time = 0f;
            AppearBullet();
        }

    }

    //void LookAt2D(GameObject target)
    //{
    //    // 指定オブジェクトと回転さすオブジェクトの位置の差分(ベクトル)
    //    Vector3 pos = target.transform.position - transform.position;
    //    // ベクトルのX,Yを使い回転角を求める
    //    float angle = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
    //    Quaternion rotation = new Quaternion();
    //    // 回転角は右方向が0度なので-90しています
    //    rotation.eulerAngles = new Vector3(0, 0, angle - 90);
    //    // 回転
    //    transform.rotation = rotation;
    //}

    void AppearBullet()
    {
        if (barrage == true)
        {
            // int number = Random.Range(0, barrage_shot.Length);
            int number = 3;
            Debug.Log(number);
            switch (number)
            {
                case 3:
                    for (int i = 0; i <= (n_way - 1); i++)
                    {
                        // n-way弾の端から端までの角度
                        float AngleRange = PI * (Degree / 180);

                        // 弾インスタンスに渡す角度の計算
                        if (n_way > 1) _theta = (AngleRange / (n_way - 1)) * i - 0.5f * AngleRange;
                        else _theta = 0;

                        GameObject Bullet_obj = Instantiate(barrage_shot[2], transform.position, transform.rotation);
                        B_FB bullet_cs = Bullet_obj.GetComponent<B_FB>();
                        bullet_cs.theta = _theta;
                        bullet_cs.Velocity_0 = _velocity_0;
                        Debug.Log(AngleRange);
                    }
                    // Debug.Log("たぶんNWay弾");
                    break;
                case 2:
                    // バースト                 
                    for (int i = 0; i < 3; i++)
                    {
                        for (burst_Delay = 0; burst_Delay < 3; burst_Delay++)
                        {                                                    
                             Instantiate(barrage_shot[1], transform.position, transform.rotation);                           
                        }
                    }
                    Debug.Log("たぶんバースト弾");
                    break;
                case 1:
                    Instantiate(barrage_shot[0], transform.position, Quaternion.Euler(0f, 0f, 0f));
                    Debug.Log("たぶんホーミング弾");
                    break;
                default:
                    break;
            }

        }
        else
        {
            Instantiate(Boss_FB, transform.position, Quaternion.Euler(0f, 0f, 0f));
        }

        numOfbullet++;

    }

}
