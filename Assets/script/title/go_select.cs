using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class go_select : MonoBehaviour { 

    bool start=true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (start == true)
        {
            if (Input.touchCount > 0)
            {
                foreach (Touch t in Input.touches)
                {
                    start = false;
                    FadeManager.Instance.LoadScene("select", 1.0f);

                }
            }
        }
        if (Input.GetKeyDown("space")) {
            FadeManager.Instance.LoadScene("select", 1.0f);
        }
    }
}
