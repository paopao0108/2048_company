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
        // 保存选择的游戏模式
        PlayerPrefs.SetInt(Constant.GameModel, modeCount);
        // 跳转场景到游戏场景
        SceneManager.LoadSceneAsync(1);
    }

    public void OnStartGameClick()
    {

    }
}
