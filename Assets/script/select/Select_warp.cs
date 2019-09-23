using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select_warp : MonoBehaviour
{
    [SerializeField] string select_name;
    [SerializeField] GameObject player;

    void Start()
    {
        player = GameObject.Find("player");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            FadeManager.Instance.LoadScene(select_name, 2.0f);
            player.SetActive(false);
        }
    }
}
