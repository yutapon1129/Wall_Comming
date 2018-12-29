using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public float walkForce = 10f; //スピード
    public float flyForce = 1f; //ジャンプ力
    [Range(0, 1)] public float sliding = 0.9f; //スライドモーション

    private void Update()
    {
        // 左右のキー変数
        float h = Input.GetAxis("Horizontal");

        // 速度の変数
        Vector2 v = GetComponent<Rigidbody2D>().velocity;

        if (h != 0)
        {
            // 左右の移動
            GetComponent<Rigidbody2D>().velocity = new Vector2(h * walkForce, v.y);
            transform.localScale = new Vector2(Mathf.Sign(h), transform.localScale.y);
        }
        else
        {
            // スライドモーション
            GetComponent<Rigidbody2D>().velocity = new Vector2(v.x * sliding, v.y);
        }

        //ジャンプ
        if (Input.GetKey(KeyCode.UpArrow))
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * flyForce);
    }

}