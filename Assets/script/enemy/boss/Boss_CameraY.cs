using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Stage_Bossを常にカメラの高さに合わせるスクリプト。

public class Boss_CameraY : MonoBehaviour
{
    [SerializeField] GameObject Camera;     //メインカメラ格納用
    private float Start_Transform;          //Bossの初期y座標格納用

    int dire;

    void Start()
    {
        //ステージ開始地点でのy座標を格納
        Start_Transform = transform.position.y;
    }
    void Update()
    {
        //カメラの高さに合わせてボスも移動
        transform.position = new Vector2(transform.position.x, Start_Transform + Camera.transform.position.y);
    }
}
