using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select_warp : MonoBehaviour
{
    [SerializeField] string select_name;
    [SerializeField] GameObject player;

    private GameObject Memory;
    private GameObject Memory_world;
    [SerializeField] float next_X, next_Y;  //次のワールドの初期座標
    Locationmemory Code;

    void Start()
    {
        player = GameObject.Find("player");

        Memory = GameObject.Find("location memory");    //座標記録オブジェクト取得
        Code = Memory.GetComponent<Locationmemory>();   //オブジェクト内のスクリプト取得
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            Code.player_x = next_X;
            Code.player_y = next_Y;

            player.SetActive(false);
            FadeManager.Instance.LoadScene(select_name, 2.0f);
            
        }
    }
}
