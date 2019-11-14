using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_ground : MonoBehaviour
{
    private Vector3 initialPosition;        // 自身の座標格納   
    [Header("各種設定")]
    [SerializeField] float Distance;        // 床の移動範囲
    [SerializeField] float speed;           // 床の移動速度

    [Space(10)]

    [Tooltip("true = 左右移動   false = 上下移動")]
    [SerializeField] bool MoveDirection;    // 床の移動方向

    [Space(10)]

    [Tooltip("true = 負の方向   false = 上下移動")]
    [SerializeField] bool Arrow;    // 床の移動方向


    // Use this for initialization
    private void Start()
    {
        initialPosition = transform.position;
    }

    private void FixedUpdate()
    {
        if (MoveDirection == true)
        {
            if (Arrow)
            {
                transform.position = new Vector2(Mathf.PingPong(Time.time * speed, Distance) * -1 + initialPosition.x, initialPosition.y);
            }
            else
            {
                transform.position = new Vector2(Mathf.PingPong(Time.time * speed, Distance) + initialPosition.x, initialPosition.y);
            }
        }
        else
        {
            if (Arrow)
            {
                transform.position = new Vector2(initialPosition.x, initialPosition.y + Mathf.PingPong(Time.time * speed, Distance) * -1);
            }
            else
            {
                transform.position = new Vector2(initialPosition.x, Mathf.PingPong(Time.time * speed, Distance) + initialPosition.y);
            }
        }
    }
}
