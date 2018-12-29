using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class text_inout : MonoBehaviour {

    float alfa;
    float speed = 0.01f;
    float red, green, blue;
    bool FD = true;

    // Start is called before the first frame update
    void Start()
    {
        red = GetComponent<Text>().color.r;
        green = GetComponent<Text>().color.g;
        blue = GetComponent<Text>().color.b;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (FD == true)
        {
            GetComponent<Text>().color = new Color(red, green, blue, alfa);
            alfa += speed;

            Debug.Log(alfa);
            if (alfa >= 1)
            {
                FD = false;
                
            }
        }

        if (FD == false)
        {
            GetComponent<Text>().color = new Color(red, green, blue, alfa);
            alfa -= speed;
            if (alfa <= 0)
            {
                FD = true;
            }
        }
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            foreach (Touch t in Input.touches)
            {
                speed = 0.1f;
            }
        }
    }
}
