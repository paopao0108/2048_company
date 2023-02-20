using System.Collections;
using System.Collections.Generic;
using Script.Constant;
using Script.View;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectPanel : Common
{
    public void OnSelectModeClick(int modeCount)
    {
        // ����ѡ�����Ϸģʽ
        PlayerPrefs.SetInt(Constant.GameModel, modeCount);
        // ��ת��������Ϸ����
        SceneManager.LoadSceneAsync(1);
    }

    public void OnStartGameClick()
    {

    }
}
