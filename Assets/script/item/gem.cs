using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gem : MonoBehaviour
{
    public GameObject player ,gemlight;

    private const string MAIN_CAMERA_TAG_NAME = "MainCamera";   //ﾒｲﾝｶﾒﾗ格納
    private bool _isRendered = false;                           //ｶﾒﾗ真偽

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
        if (_isRendered)
        {
            if (collision.gameObject.tag == "player")
            {
                Destroy(gameObject);
                Instantiate(gemlight, transform.position, transform.rotation);
                player.GetComponent<PlayerExtra>().gemup();
            }

            if (collision.gameObject.tag == "boss")
            {
                Destroy(gameObject);
                Instantiate(gemlight, transform.position, transform.rotation);
            }
        }
    }
    public void delete()
    {
        Destroy(gameObject);
    }

    void OnWillRenderObject()
    {
        //メインカメラに映った時だけ_isRenderedをtrue
        if (Camera.current.tag == MAIN_CAMERA_TAG_NAME)
        {
            _isRendered = true;
        }
    }
}
