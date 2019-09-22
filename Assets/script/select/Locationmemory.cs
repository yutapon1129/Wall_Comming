using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locationmemory : MonoBehaviour
{
    public float player_x, player_y;                  //入ったｸﾘｽﾀﾙのx座標記録用

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);      //ロード時破壊不可能に
    }

    public void Memo()
    {

    }
}
