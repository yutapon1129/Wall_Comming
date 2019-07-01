using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class FadeOut : MonoBehaviour
{
    public PlayableDirector playableDirector;


    // Start is called before the first frame update
    void Start()
    {
        //同じゲームオブジェクトにあるPlayableDirectorを取得する
        playableDirector = GetComponent<PlayableDirector>();
    }

   
}
