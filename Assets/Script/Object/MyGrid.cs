using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGrid : MonoBehaviour
{
    private Number number;
    // �ж��Ƿ�������
    public bool IsHasNumber()
    {
        return number != null; // ��ǰ����û�����֣��򷵻�false
    }

    // ��ȡ�����ϵ�����
    public Number GetNumber()
    {
        return this.number;
    }

    // ���ø����ϵ�����
    public void SetNumber(Number number)
    {
        this.number = number;
    }
}
