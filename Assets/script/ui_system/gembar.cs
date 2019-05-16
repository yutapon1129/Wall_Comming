using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gembar : MonoBehaviour
{
    public GameObject player;
    Slider gemslider;
    private float g_power;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        gemslider = GameObject.Find("GemPower").GetComponent<Slider>();

        g_power = player.GetComponent<PlayerExtra>().gempower;
        gemslider.maxValue = 15;
    }


    // Update is called once per frame
    void Update()
    {
        g_power = player.GetComponent<PlayerExtra>().gempower;
        gemslider.value = g_power;
    }
}
