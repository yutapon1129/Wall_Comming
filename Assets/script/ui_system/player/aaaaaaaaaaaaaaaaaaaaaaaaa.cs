using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class aaaaaaaaaaaaaaaaaaaaaaaaa : MonoBehaviour
{

    public CinemachineVirtualCamera vcamera;

    public GameObject PPPPP;

    // Start is called before the first frame update
    void Start()
    {
        PPPPP = GameObject.Find("player");
        //Vector3 itemp = PPPPP.transform.position;
        //Transform TTTtemp = itemp;

        vcamera.Follow = PPPPP.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
