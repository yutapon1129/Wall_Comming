using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FB : MonoBehaviour
{
    private GameObject player;
    [SerializeField] float speed = 2.5f;

    void Start()
    {
        ////player取得
        player = GameObject.Find("player");

        //var pos = gameObject.transform.position;
        //Vector2 vec = player.transform.position - pos;

        GetComponent<Rigidbody2D>().velocity = transform.up * speed;
        Destroy(gameObject, 30);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "ground" || col.gameObject.tag == "boss")
        {
            Destroy(gameObject);
        }
    }
}
