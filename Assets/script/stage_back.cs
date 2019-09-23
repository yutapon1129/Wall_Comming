using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class stage_back : MonoBehaviour
{
    bool go = true;
    GameObject re_bool; //リスタートしたか否かの判定オブジェクト格納用

    public PlayableDirector playableDirector; //fadetimeline 格納
    public GameObject Fade_out_object;

    public void back()
    {
        Debug.Log(go);
        if (go == true)
        {
            re_bool = GameObject.Find("restart_bool");
            re_bool.GetComponent<R_bool>().delete();
            FadeManager.Instance.LoadScene("select", 1.0f);
            go = false;
        }
    }
}
