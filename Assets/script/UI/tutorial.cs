using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class tutorial : MonoBehaviour
{
    // 一つ前のシーン名
    private string beforeScene = "select";

    void start()
    {
        // シーン切替時も破壊しないようにする
        DontDestroyOnLoad(gameObject);

        // シーンが切り替わったときに呼ばれるメソッドを登録
        SceneManager.activeSceneChanged += OnActiveSceneChanged;
    }

    // シーンが切り替わったときに呼ばれるメソッド
    void OnActiveSceneChanged(Scene prevScene, Scene nextScene)
    {
        // シーンがどう変わったかで判定

        // ステージセレクトからチュートリアルへ
        if (beforeScene == "select" && nextScene.name == "tutorial")
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
