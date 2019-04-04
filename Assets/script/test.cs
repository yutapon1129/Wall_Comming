using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    public bool isGround = false;
    private float maxFallSpeed = -15.0f;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        var speed = 10.0f;
        var xv = speed * Input.GetAxis("Horizontal");

        _rigidbody.velocity = new Vector2(xv, Mathf.Max(maxFallSpeed, _rigidbody.velocity.y));

        var jumpPower = 10.0f;
        if (isGround && Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpPower);
        }
        if (!isGround && _rigidbody.velocity.y > 0.0f && Input.GetKey(KeyCode.Space))
        {
            _rigidbody.gravityScale = 0.5f;
        }
        else
        {
            _rigidbody.gravityScale = 1.0f;
        }
    }
}
