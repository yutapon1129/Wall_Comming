using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chikuwa_trigger : MonoBehaviour
{
    private string playerTag = "player";
    private bool isOn = false;
    private bool callFixed = false;

    void Start()
    {
        
    }

    // プレイヤーが上に乗っているかどうかの判定
    public bool IsPlayerOn()
    {
        return isOn;
    }

    private void FixedUpdate()
    {
        callFixed = true;
    }

    private void LateUpdate()
    {
        if (callFixed)
        {
            // フラグ戻し
            isOn = false;
            callFixed = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == playerTag)
        {
            if(collision.transform.position.y - (collision.bounds.size.y / 4.0f) > transform.position.y)
            {
                isOn = true;
            }
        }
    }
}
