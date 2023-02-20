using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPanel : MonoBehaviour
{
    public SelectPanel selectPanel;

    public SetPanel setPanel;

    // 点击开始
    public void OnStartClick()
    {
        // 显示选择模式
        selectPanel.Show();
    }
    
    // 点击设置
    public void OnSetClick()
    {
        setPanel.Show();
    }

    public void OnExitClick()
    {
        
    }
}
