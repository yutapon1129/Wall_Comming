using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_HP : MonoBehaviour {

    public Rigidbody2D rigidbody2D;
    public GameObject explosion;
    public int speed = -3, x = 1;

    //カメラ関係
    private const string MAIN_CAMERA_TAG_NAME = "MainCamera";
    private bool _isRendered = false;
    //体力関係
    public int HP;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (_isRendered)
        {
            if (col.tag == "bullet")
            {
                HP = HP - 1;
                if (HP == 0)
                {
                    Destroy(gameObject);
                    Instantiate(explosion, transform.position, transform.rotation);
                }
            }
            if (col.tag == "boss")
            {
                Destroy(gameObject);
                Instantiate(explosion, transform.position, transform.rotation);
            }

            if (col.tag == "ground" || col.tag == "enemy")
            {

                speed = speed * -1;
                x = x * -1;
                transform.localScale = new Vector2(x, 1);
            }
        }
    }

    //Rendererがカメラに映ってる間に呼ばれ続ける
    void OnWillRenderObject()
    {
        //メインカメラに映った時だけ_isRenderedをtrue
        if (Camera.current.tag == MAIN_CAMERA_TAG_NAME)
        {
            _isRendered = true;
        }
    }
}
