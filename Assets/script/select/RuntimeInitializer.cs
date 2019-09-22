﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RuntimeInitializer : MonoBehaviour
{
    //ゲーム開始時(シーン読み込み前)に実行される
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void LoadManagerScene()
    {
        string managerSceneName = "manager";

        //ManagerSceneが有効でない時(まだ読み込んでいない時)だけ追加ロードするように
        if (!SceneManager.GetSceneByName(managerSceneName).IsValid())
        {
            SceneManager.LoadScene(managerSceneName, LoadSceneMode.Additive);
        }
    }
}
