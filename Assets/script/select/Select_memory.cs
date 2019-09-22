using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// プレイ中のワールドの記録。
/// </summary>
public class Select_memory : MonoBehaviour
{
    public int world_number;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);      //ロード時破壊不可能に
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
