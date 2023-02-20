using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectModePanel : Common
{
    // 选择模式
    public void OnSelectModeClick(int count)
    {
        // 1. 保存选择的模式
        PlayerPrefs.SetInt(Const.GameModel, count);

        // 2. 跳转到模式对应的游戏场景中（场景跳转）
        SceneManager.LoadSceneAsync(1);
    }
}
