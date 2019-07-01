using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

// A behaviour that is attached to a playable
public class Fade_Behaviour : PlayableBehaviour
{
    public string scene;


    // PlayableAsset から引き渡す.
    private int mIntSample;
    public int IntSample { set { mIntSample = value; } }
    private GameObject mGameObjectSample;
    public GameObject GameObjectSample { set { mGameObjectSample = value; } }

    // Called when the owning graph starts playing
    public override void OnGraphStart(Playable playable)
    {
        
    }

    // Called when the owning graph stops playing
    public override void OnGraphStop(Playable playable)
    {
       // SceneManager.LoadScene("select");
        Debug.Log("aaaaa");
    }

    // Called when the state of the playable is set to Play
    public override void OnBehaviourPlay(Playable playable, FrameData info)
    {
        
    }

    // Called when the state of the playable is set to Paused
    public override void OnBehaviourPause(Playable playable, FrameData info)
    {
        
    }

    // Called each frame while the state is set to Play
    public override void PrepareFrame(Playable playable, FrameData info)
    {
        
    }
}
