using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_flower_bullet : MonoBehaviour
{
    Vector2 A, C, AB, AC;       // ベクトル
    Transform target;           // 追いかける対象

    public float speed;         // 移動スピード
    public float maxRot;        // 曲がる最大角度
    public float lifetime;      // 弾の消える時間
    public bool three_way;      // 弾が3way弾になる
    public bool burst;          // 弾がバーストになる

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("player").transform;
        transform.eulerAngles += new Vector3(0, 0, Nasu());
        GetComponent<Rigidbody2D>().velocity = transform.up.normalized * speed;
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        Move(Nasu());
    }

    float Nasu()
    {
        A = transform.position;     // 自身の座標
        C = target.position;        // ターゲットの座標

        AB = transform.right;          // 自身の右方向ベクトル
        AC = C - A;                 // ターゲットの方向ベクトル

        float dot = Vector3.Dot(AB, AC);        // 内積
        float rot = Acosf(dot / (Length(AB) * Length(AC)));     // アークコサインからΘを求める

        // 外積から回転方向を求める
        if(AB.x * AC.y - AB.y * AC.x < 0)
        {
            rot = -rot;
        }

        return rot * 180f / Mathf.PI;       // ラジアンからデグリーに変換して角度を返す

    }

    void Move(float rot)
    {
        // 求めた角度が曲がる最大角度より大きかった場合に戻す処理
        if(rot > maxRot)
        {
            rot = maxRot;
        }
        else if(rot < -maxRot)
        {
            rot = -maxRot;
        }
        transform.eulerAngles += new Vector3(0, 0, rot);        // 回転
        GetComponent<Rigidbody2D>().velocity = AB * speed;      // 上に移動
    }

    float Length(Vector2 vec)
    {
        return Mathf.Sqrt(vec.x * vec.x + vec.y * vec.y);
    }
    float Acosf(float a)
    {
        if (a < -1) a = -1;
        if (a > 1) a = 1;

        return (float)Mathf.Acos(a);
    }

}
