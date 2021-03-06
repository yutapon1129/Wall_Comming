﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bone : MonoBehaviour
{
    public GameObject skeleton;
    public float speed;
    Rigidbody2D rb;

    //void Start()
    //{
    //    skeleton = GameObject.Find("skeleton");
    //    Debug.Log(skeleton.transform.localScale.x);
    //    //Rigidbody2Dの取得
    //    Rigidbody2D rb = GetComponent<Rigidbody2D>();
    //    //skeletonの向きに飛ばす
    //    rb.velocity = new Vector2(speed * -1 * skeleton.transform.localScale.x, rb.velocity.y);
    //    //骨の向きを合わせる
    //    Vector2 temp = transform.localScale;
    //    temp.x = skeleton.transform.localScale.x;
    //    transform.localScale = temp;
    //    //5秒後消滅
    //    Destroy(gameObject, 5);
    //}

    public void Create(float rl)
    {
        Debug.Log("読まれたわよ♡");
        speed = speed * rl * -1;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        //skeletonの向きに飛ばす
        rb.velocity = new Vector2(speed, rb.velocity.y);
        //骨の向きを合わせる
        Vector2 temp = transform.localScale;
        temp.x = rl / 2;
        transform.localScale = temp;
        //5秒後消滅
        Destroy(gameObject, 5);
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        //指定したタグのオブジェクトにぶつかったら消滅
        if (collision.gameObject.tag == "ground" || collision.gameObject.tag == "boss")
        {
            Destroy(gameObject);
        }
        //collision.gameObject.tag == "enemy" ||        ｴﾈﾐｰ当たったら消す

        //collision.gameObject.GetComponent<Rigidbody2D>();
    }
}
