using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTriggerIn : MonoBehaviour
{
    private string playerTag = "Player";
    private bool isIn = false;
    private bool callFixed = false;

    /// <summary>
    /// プレイヤーが判定の範囲内にいるかどうか
    /// </summary>
    /// <returns><c>true</c>, if player on was ised, <c>false</c> otherwise.</returns>
    public bool IsPlayerIn()
    {
        return isIn;
    }


    private void LateUpdate()
    {
        if (callFixed)
        {
            //フラグを元に戻します
            isIn = false;
            callFixed = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == playerTag)
        {
            isIn = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == playerTag)
        {
            isIn = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == playerTag)
        {
            isIn = false;
        }
    }
}
