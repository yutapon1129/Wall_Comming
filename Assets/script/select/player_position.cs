using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_position : MonoBehaviour
{

    //uiloadから読み込んだplayerの位置+左右の向きを調節するスクリプト
    GameObject player;
    public float positionX, positionY;
    public bool rotate = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        player.transform.position = new Vector2(positionX, positionY);

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
