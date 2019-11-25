using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class atkpower : MonoBehaviour
{
    public Text text;
    public GameObject player;
    float player_atk;

    // Update is called once per frame
    void Update()
    {
        player_atk = player.GetComponent<PlayerExtra>().atk;
        text.text = "ATK  " + player_atk;
    }
}
