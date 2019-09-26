using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_test : MonoBehaviour
{
    float speed = 10; // 実際に動かしてみて速度調整してください
    GameObject obj;
    void Start()
    {
        //objに指定オブジェクトを予め入れておいてください
        obj= GameObject.Find("player");
    }

    void Update()
    {
          LookAt2D(obj);

        if (transform.localEulerAngles.z > 0 && 180 > transform.localEulerAngles.z)
        {
            transform.localScale = new Vector2(1, 1);
            Debug.Log("+");
        }
        else
        {
            transform.localScale = new Vector2(-1, 1);
            Debug.Log("+");
        }

        //if (transform.localEulerAngles.z > -180 || 0 > transform.localEulerAngles.z)
        //{
        //    transform.localScale = new Vector2(-1, 1);
        //}
    }

    void LookAt2D(GameObject target)
    {
        // 指定オブジェクトと回転さすオブジェクトの位置の差分(ベクトル)
        Vector3 pos = target.transform.position - transform.position;
        // ベクトルのX,Yを使い回転角を求める
        float angle = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
        Quaternion rotation = new Quaternion();
        // 回転角は右方向が0度なので-90しています
        rotation.eulerAngles = new Vector3(0, 0, angle - 90);
        // 回転
        transform.rotation = rotation;
    }
}

