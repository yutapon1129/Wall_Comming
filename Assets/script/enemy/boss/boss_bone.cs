using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_bone : MonoBehaviour
{
    Rigidbody2D rb;

    public int speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        //skeletonの向きに飛ばす
        rb.velocity = new Vector2(speed, rb.velocity.y);
        Destroy(gameObject, 60);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
