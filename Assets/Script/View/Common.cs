using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Common : MonoBehaviour
{
    // ��ʾ������Ϊ�鷽�����Ա���д��
    public virtual void Show()
    {
        gameObject.SetActive(true);
    }

    // ����
    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }
}
