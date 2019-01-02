using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stage_reload : MonoBehaviour
{
    bool reload;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(reload);
        if (reload == true)
        {
            SceneManager.LoadScene(0);
        }
    }

    private void FixedUpdate()
    {

    }

    public void back()
    {
        reload = true;
    }
}