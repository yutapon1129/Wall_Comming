using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

    private GameObject player;
    private int speed = 40;

    void Start()
    {
        //player取得
        player = GameObject.Find("player");
        //rigidbody2Dコンポーネントを取得
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
        //playerの向きに飛ばす
        rigidbody2D.velocity = new Vector2(speed * player.transform.localScale.x, rigidbody2D.velocity.y);
        //画像の向きを合わせる
        Vector2 temp = transform.localScale;
        temp.x = player.transform.localScale.x;
        transform.localScale = temp;
        //5秒後に消滅
        Destroy(gameObject, 3);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "enemy" || col.gameObject.tag == "ground"|| col.gameObject.tag == "boss")
        {
            Destroy(gameObject);
        }
    }
}
