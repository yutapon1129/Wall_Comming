using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;      // visualstudioでエラー出ても問題ないです。

// CinemachineVirtualCameraにinspector上で直接playerを入れられないから
// 代わりにスクリプトで入れてあげるもの

public class Cinemachine_system : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera vcamera;    // スクリプト格納
    [SerializeField] GameObject Player_Box;     // player格納

    void Start()
    {
        Player_Box = GameObject.FindWithTag("player");      // player格納
        vcamera.Follow = Player_Box.transform;              // 追従カメラシステムのFollowにPlayerのTransformを入れる
    }
}
