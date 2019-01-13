using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public bool followcamera;
    public float offset;
    private Vector3 oldpos;
    private Vector3 oldcampos;

    // Use this for initialization
    void Start()
    {
        oldpos = transform.position;
        oldcampos = Camera.main.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (followcamera)
        {
            Vector3 v = new Vector3((Camera.main.transform.position.x - oldcampos.x) / offset, 0, 0);
            transform.localPosition = oldpos + v;
        }
        else
        {
            Vector3 v = new Vector3((oldcampos.x - Camera.main.transform.position.x) / offset, 0, 0);
            transform.localPosition = oldpos + v;
        }
    }
}