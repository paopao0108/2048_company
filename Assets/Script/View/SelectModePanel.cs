using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectModePanel : Common
{
    // ѡ��ģʽ
    public void OnSelectModeClick(int count)
    {
        // 1. ����ѡ���ģʽ
        PlayerPrefs.SetInt(Const.GameModel, count);

        // 2. ��ת��ģʽ��Ӧ����Ϸ�����У�������ת��
        SceneManager.LoadSceneAsync(1);
    }
}
