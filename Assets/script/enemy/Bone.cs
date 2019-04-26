using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bone : MonoBehaviour
{
    public GameObject skeleton;
    public float speed;
    Rigidbody2D rb;

    void Start()
    {
        //Rigidbody2Dの取得
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        //skeletonの向きに飛ばす
        rb.velocity = new Vector2(speed * skeleton.transform.localScale.x, rb.velocity.y);
        //骨の向きを合わせる
        Vector2 temp = transform.localScale;
        temp.x = skeleton.transform.localScale.x;
        transform.localScale = temp;
        //5秒後消滅
        Destroy(gameObject, 5);
        Debug.Log(skeleton.transform.localScale.x);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //指定したタグのオブジェクトにぶつかったら消滅
        if (collision.gameObject.tag == "ground" || collision.gameObject.tag == "boss")
        {
            Destroy(gameObject);
        }

        //collision.gameObject.tag == "enemy" ||        ｴﾈﾐｰ当たったら消す
    }
}
