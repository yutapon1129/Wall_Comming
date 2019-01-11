using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stage_back : MonoBehaviour
{
    bool go = true;

    public void back()
    {
        Debug.Log(go);
        if (go == true)
        {
            FadeManager.Instance.LoadScene("select", 1.0f);
            go = false;
        }

    }
}
