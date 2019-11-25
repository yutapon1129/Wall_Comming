using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;


[System.Serializable]
public class FadeInPlayableAsset : PlayableAsset
{
    //UIテキストを格納
    [SerializeField] private ExposedReference<GameObject> text;
    //fadeのスピード
    [SerializeField] private float fadeInSpeed;
    [SerializeField] private float fadeOutSpeed;
    [SerializeField] private bool isFadeOut;
    [SerializeField] private bool isFadeIn;

    [SerializeField] private float fadeOutTime;
    private Color textColor;

    // Factory method that generates a playable based on this asset
    public override Playable CreatePlayable(PlayableGraph graph, GameObject go)
    {
        var behaviour = new FadeInPlayableBehaviour //インスペクターの設定を反映させる
        {
            text = text.Resolve(graph.GetResolver()),
            textColor = textColor,
            fadeInSpeed = fadeInSpeed,
            fadeOutSpeed = fadeOutSpeed,
            fadeOutTime = fadeOutTime,
            isFadeOut = isFadeOut,
            isFadeIn = isFadeIn,

        };
        return ScriptPlayable<FadeInPlayableBehaviour>.Create(graph, behaviour);
    }
}
