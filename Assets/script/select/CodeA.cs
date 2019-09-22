using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeA : MonoBehaviour
{

    [SerializeField] GameObject ObjectB;
    CodeB codeB;

    // Use this for initialization
    void Start()
    {
        //Bのスクリプトを取得
        //ObjectB = GameObject.Find("ObjectB");
        codeB = ObjectB.GetComponent<CodeB>();
    }
    // Update is called once per frame
    void Update()
    {
        //Bを呼び出す
        codeB.A = 15f;
    }
}
