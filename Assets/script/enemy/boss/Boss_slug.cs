using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_slug : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;

    [SerializeField] GameObject B_slug;         //自分自身格納用
    [SerializeField] int MyHP, MyHP_before;     //自身の体力
    bool speed_bool = true;                     //速度上昇用

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        MyHP_before = B_slug.GetComponent<Boss_HP>().HP;
    }

    void Update()
    {
        MyHP = B_slug.GetComponent<Boss_HP>().HP;    //自分自身の体力を習得

        if (speed_bool == true)
        {
            if (MyHP_before / 3 >= MyHP)
            {
                speed = speed * 2;
                speed_bool = false;
            }
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }
}
