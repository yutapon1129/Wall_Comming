using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameover_system : MonoBehaviour
{
    bool re = true;

    public void gameover()
    {
        if (re == true)
        {
            // 現在のScene名を取得する
            Scene loadScene = SceneManager.GetActiveScene();
            // Sceneの読み直し
            FadeManager.Instance.LoadScene(loadScene.name, 1.0f);
            //SceneManager.LoadScene(loadScene.name);
            re = false;
        }
    }
}
