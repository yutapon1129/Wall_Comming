using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stage_back : MonoBehaviour
{

    bool go;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(go);
        if (go == true)
        {
            // FadeManager.Instance.LoadScene("select", 1.0f);
            SceneManager.LoadScene("select");
        }
    }

    private void FixedUpdate()
    {
        
    }

    public void back()
    {
        go = true;
    }
}
