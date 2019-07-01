using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

[System.Serializable]
public class Fade_Asset : PlayableAsset
{
    
        // Factory method that generates a playable based on this asset
    public override Playable CreatePlayable(PlayableGraph graph, GameObject go)
    {
        Fade_Behaviour db = new Fade_Behaviour();//新規追加
        return ScriptPlayable<Fade_Behaviour>.Create(graph, db);//新規追加
                                                                 //return Playable.Create(graph); //ここはテンプレートにあるが削除する
    }
}

