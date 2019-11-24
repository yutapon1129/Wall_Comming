using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class start_movie : MonoBehaviour
{
    [SerializeField] PlayableDirector playableDirector;
    private bool Restart;
    private GameObject Rsystem;
    [SerializeField] GameObject BOSS;   //再生後に動かすボス格納

    void Awake()
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
            playableDirector.time = 4.5f;
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


    void OnEnable()
    {
        playableDirector.stopped += OnPlayableDirectorStopped;
    }

    void OnPlayableDirectorStopped(PlayableDirector aDirector)
    {
        if (playableDirector == aDirector)
        {
            // timeline終了時の処理
            BOSS.GetComponent<Boss_normalmove>().enabled = true;
            Debug.Log("PlayableDirector named " + aDirector.name + " is now stopped.");
        }

    }

    void OnDisable()
    {
        playableDirector.stopped -= OnPlayableDirectorStopped;
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
