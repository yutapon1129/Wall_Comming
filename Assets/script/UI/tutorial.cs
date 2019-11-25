using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class tutorial : MonoBehaviour
{
    // ��O�̃V�[����
    private string beforeScene = "select";

    void start()
    {
        // �V�[���ؑ֎����j�󂵂Ȃ��悤�ɂ���
        DontDestroyOnLoad(gameObject);

        // �V�[�����؂�ւ�����Ƃ��ɌĂ΂�郁�\�b�h��o�^
        SceneManager.activeSceneChanged += OnActiveSceneChanged;
    }

    // �V�[�����؂�ւ�����Ƃ��ɌĂ΂�郁�\�b�h
    void OnActiveSceneChanged(Scene prevScene, Scene nextScene)
    {
        // �V�[�����ǂ��ς�������Ŕ���

        // �X�e�[�W�Z���N�g����`���[�g���A����
        if (beforeScene == "select" && nextScene.name == "tutorial")
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
