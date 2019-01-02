using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stage_back : MonoBehaviour
{

    public void back ()
    {
       FadeManager.Instance.LoadScene("select", 1.0f);
    }
}
