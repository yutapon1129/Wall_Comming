using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMainSystem : MonoBehaviour
{
    [SerializeField]
    ClickController clickController;
    void Update()
    {
        clickController.ViewClickIcon();
        /*if (textController.finished)
        {
            textController.finished = false;
            clickController.ViewClickIcon();
            return;
        }*/
    }
}
