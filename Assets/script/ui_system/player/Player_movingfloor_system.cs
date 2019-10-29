using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movingfloor_system : MonoBehaviour
{
    [SerializeField] GameObject Player_Parent;

    //動く床に乗ったら乗った床の子オブジェクトに
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Move")
        {
            Debug.Log("お”お”お”お”お”お”ん”");
            //Player_Parent.transform.parent = other.gameObject.transform;

            Player_Parent.GetComponent<PlayerMove>().Floor_Enter(other.gameObject.transform);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {

        if (transform.parent != null && other.gameObject.tag == "Move")
        {
            Player_Parent.transform.parent = null;

        }
    }
}
