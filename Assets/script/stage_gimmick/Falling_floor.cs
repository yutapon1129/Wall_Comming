using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling_floor : MonoBehaviour
{
    Rigidbody2D rb;                     //rigidbody格納用
    private bool floor_bool;            //乗ってるか否か  
    private bool shake_bool = true;     //ゆらしたか否か
    [SerializeField] float speed;       //落下速度
    [SerializeField] float shaketime;   //揺れる時間
    [SerializeField] float shakewide;   //揺れる幅

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  //Rigidbody取得
    }

    void FixedUpdate()
    {
        if(floor_bool == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (shake_bool == true)
        {
            Invoke("StartFall", 2);
            StartCoroutine(DoShake());
        }
    }

    void StartFall()
    {
        floor_bool = true;
    }

    private IEnumerator DoShake()
    {
        shake_bool = false;     //一度だけ揺らす為

        var pos = transform.localPosition;

        var elapsed = 0f;

        while (elapsed < shaketime)
        {
            var x = pos.x + Random.Range(-1f, 1f) * shakewide;
            //var y = pos.y + Random.Range(-1f, 1f) * shakewide;        //y軸にもゆらす場合

            transform.localPosition = new Vector3(x, pos.y, pos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = pos;
    }
}
