using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPanel : MonoBehaviour
{
    public SelectModePanel selectModelPanel;
    public SetPanel setPanel;

    

    // �����ʼ��ť
    public void OnStartClick()
    {
        // ��ת��ѡ��ģʽҳ��
        selectModelPanel.Show();

    }

    // ������ð�ť
    public void OnSettingClick()
    {
        // ��ת������ҳ��
        setPanel.Show();
    }

    // ����˳���ť
    public void OnExitClick()
    {

    }
}
