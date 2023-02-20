using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPanel : MonoBehaviour
{
    public SelectModePanel selectModelPanel;
    public SetPanel setPanel;

    

    // 点击开始按钮
    public void OnStartClick()
    {
        // 跳转到选择模式页面
        selectModelPanel.Show();

    }

    // 点击设置按钮
    public void OnSettingClick()
    {
        // 跳转到设置页面
        setPanel.Show();
    }

    // 点击退出按钮
    public void OnExitClick()
    {

    }
}
