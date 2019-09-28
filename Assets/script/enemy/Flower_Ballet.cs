using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower_Ballet : MonoBehaviour
{
    [SerializeField] GameObject FB, obj;

    void Start()
    {
        //objに指定オブジェクトを予め入れておいてください
        obj = GameObject.Find("player");
    }

    void Update()
    {
        LookAt2D(obj);
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


    public void shot()
    {
        Instantiate(FB, transform.position, transform.rotation);
    }

}
