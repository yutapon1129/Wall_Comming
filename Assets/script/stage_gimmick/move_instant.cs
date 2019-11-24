using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_instant : MonoBehaviour
{
    Rigidbody2D rb;
    float timeElapsed;                      //時間計測変数格納用
    bool Number = false;
    [SerializeField] float speed,           //床移動速度
                           deletetime;         //消える時間

    [Tooltip("true = 左右移動   false = 上下移動")]
    [SerializeField]
    bool MoveDirection;    // 床の移動方向


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  //Rigidbody取得
    }

    public void Create(float a, float b)
    {
        deletetime = b;
        speed = a;

        Number = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Number)
        {
            if (MoveDirection)
            {
                transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);
            }

            timeElapsed += Time.timeScale;//時間計測

            if (timeElapsed >= deletetime)//設定した時間になったら読み込み
            {
                Destroy(gameObject);
            }
        }
    }
}
