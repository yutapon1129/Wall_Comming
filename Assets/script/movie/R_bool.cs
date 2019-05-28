using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_bool : MonoBehaviour
{
    public bool restart = false;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void boolchange()
    {
        restart = true;
    }

    public void delete()
    {
        Destroy(gameObject);
    }
}
