using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using System;
using UnityEngine.UI;  //UIを使用


// A behaviour that is attached to a playable
public class FadeInPlayableBehaviour : PlayableBehaviour
{

    //UIテキストを格納
    public GameObject text;
    //fadeのスピード
    public float fadeInSpeed = 2f;
    public float fadeOutSpeed = 2f;
    public float fadeOutTime;



    public Color textColor;
    private float currentTime;

    public bool isFadeOut = false;  //フェードアウト処理の開始、完了を管理するフラグ
    public bool isFadeIn = false;   //フェードイン処理の開始、完了を管理するフラグ




    public override void OnGraphStart(Playable playable)
    {
        //スタート時はテキストのアルファ値を０にする
        textColor = this.text.GetComponent<Text>().color;
        textColor.a = 0;
        this.text.GetComponent<Text>().color = textColor;

        this.text.SetActive(true);
    }

    // Called each frame while the state is set to Play
    public override void PrepareFrame(Playable playable, FrameData info)
    {
        if (isFadeIn)
        {

            StartFadeIn();
        }

        currentTime += Time.deltaTime;
        if (currentTime > fadeOutTime && isFadeOut == true)
        {
            StartFadeOut();
        }
    }

    void StartFadeIn()
    {//テキストアルファ値を徐々に増やしていく
        textColor.a += fadeInSpeed;
        this.text.GetComponent<Text>().color = textColor;
        //1以上になったらやめる
        if (textColor.a > 1)
        {
            isFadeIn = false;

        }
    }

    void StartFadeOut()
    {
        textColor.a -= fadeOutSpeed;
        this.text.GetComponent<Text>().color = textColor;
        //テキストアルファ値を徐々に減らしていく
        if (textColor.a < 0)
        {
            this.text.SetActive(false);
            isFadeOut = false;

        }
    }

    //// Called when the owning graph stops playing
    //public override void OnGraphStop(Playable playable)
    //{

    //}

    //// Called when the state of the playable is set to Play
    //public override void OnBehaviourPlay(Playable playable, FrameData info)
    //{

    //}

    //// Called when the state of the playable is set to Paused
    //public override void OnBehaviourPause(Playable playable, FrameData info)
    //{

    //}
}