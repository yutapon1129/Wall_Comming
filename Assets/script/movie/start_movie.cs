﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class start_movie : MonoBehaviour
{
    public PlayableDirector playableDirector;
    public int starttime;

    void Start()
    {
        //同じゲームオブジェクトにあるPlayableDirectorを取得する
        playableDirector = GetComponent<PlayableDirector>();
        PlayTimeline();
    }

    //再生する
    void PlayTimeline()
    {
        playableDirector.Play();
        playableDirector.time = starttime;
    }

    //一時停止する
    void PauseTimeline()
    {
        playableDirector.Pause();
    }

    //一時停止を再開する
    void ResumeTimeline()
    {
        playableDirector.Resume();
    }

    //停止する
    void StopTimeline()
    {
        playableDirector.Stop();
    }

}
