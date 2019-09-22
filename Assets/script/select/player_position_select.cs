using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_position_select : MonoBehaviour
{

    //uiloadから読み込んだplayerの位置+左右の向きを調節するスクリプト
    GameObject player;
    public float positionX, positionY;
    public bool rotate = false;

    public GameObject memory;      //入ったクリスタルの場所を記憶したオブジェクト


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        memory = GameObject.Find("location memory");
        float P_X = memory.GetComponent<Locationmemory>().player_x;
        float P_Y = memory.GetComponent<Locationmemory>().player_y;
        player.transform.position = new Vector2(P_X, (P_Y -2));

        //trueなら反転する
        if (rotate == true)
        {
            player.transform.localScale = new Vector3(player.transform.localScale.x * -1, player.transform.localScale.y, player.transform.localScale.z);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
