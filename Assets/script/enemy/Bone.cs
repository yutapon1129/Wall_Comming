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
        //rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, rb.velocity.y);

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy" || collision.gameObject.tag == "ground" || collision.gameObject.tag == "boss")
        {
            Destroy(gameObject);
        }
    }
}
