using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannon : MonoBehaviour {

    public GameObject bullet;//弾丸取得

    public void gun()
    {
        Instantiate(bullet, transform.position, transform.rotation);
    }
}
