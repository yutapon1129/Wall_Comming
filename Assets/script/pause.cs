using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{

    [SerializeField]
    //　ポーズした時に表示するUIのプレハブ
    private GameObject pauseUIPrefab;
    //　ポーズUIのインスタンス
    private GameObject pauseUIInstance;

    private bool isStop = false;

    // Update is called once per frame
    public void stop()
    {
        isStop = !isStop;
        if (isStop)
        {
            pauseUIInstance = GameObject.Instantiate(pauseUIPrefab) as GameObject;
            Time.timeScale = 0f;
        }
        else
        {
            Destroy(pauseUIInstance);
            Time.timeScale = 1f;
        }
    }
}


