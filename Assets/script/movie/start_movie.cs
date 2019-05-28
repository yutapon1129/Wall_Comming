using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class start_movie : MonoBehaviour
{
    public PlayableDirector playableDirector;
    public int starttime;
    public bool Restart;

    public GameObject Rsystem;

    void Start()
    {
        //同じゲームオブジェクトにあるPlayableDirectorを取得する
        playableDirector = GetComponent<PlayableDirector>();
        Rsystem = GameObject.Find("restart_bool");
        Restart = Rsystem.GetComponent<R_bool>().restart;
        PlayTimeline();

        if(Restart == true)
        {
            Destroy(Rsystem);
        }
    }

    //再生する
    void PlayTimeline()
    {
        if(Restart == true)
        {
            Debug.Log("restart");
            playableDirector.time = 5;
            playableDirector.Play();
        }
        else
        {
            playableDirector.time = 0;
            playableDirector.Play();
        }
        
    }

    public void Start_movie()
    {
        Restart = true;
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
