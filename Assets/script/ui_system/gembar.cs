using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gembar : MonoBehaviour
{
    public GameObject player;
    public Slider gemslider;
    private float g_power;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");

        g_power = player.GetComponent<PlayerExtra>().gempower;
        gemslider.maxValue = 20;
    }


    // Update is called once per frame
    void Update()
    {
        g_power = player.GetComponent<PlayerExtra>().gempower;
        gemslider.value = g_power;
    }
}
