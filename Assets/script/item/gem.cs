using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gem : MonoBehaviour
{
    public GameObject player;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            Destroy(gameObject);
            player.GetComponent<PlayerExtra>().gemup();
        }
    }
    public void delete()
    {
        Destroy(gameObject);
    }
}
