using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bossname : MonoBehaviour
{
    public GameObject boss;
    public string name;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.Find("stage_boss");
        name = boss.GetComponent<boss>().name;
        text.text = name;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
