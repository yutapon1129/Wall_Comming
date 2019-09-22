using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeB : MonoBehaviour
{
    public float A;

    void Start()
    {
        //コードBでの処理を記載
        A = 3f;
    }

    void Update()
    {
        Debug.Log(A);
    }
}
