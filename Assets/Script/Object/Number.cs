using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;

public class Number : MonoBehaviour
{
    private UnityEngine.UI.Image bg;
    private TextMeshPro numberValue;

    public MyGrid InGrid; // �������ڵĸ���

    private void Awake()
    {
        bg = transform.GetComponent<UnityEngine.UI.Image>();
        numberValue = transform.Find("text").GetComponent<TextMeshPro>(); // ��ȡ���ӽڵ�text�����TextMeshPro
    }

    public void InitNumber(MyGrid myGrid)
    {
        myGrid.SetNumber(this); // ���ø����ϵ�����
        this.SetGrid(myGrid); // �����������ڸ���
        this.SetNumber(4);
    }


    // �������ֵĸ���
    public void SetGrid(MyGrid myGrid)
    {
        this.InGrid = myGrid;
    }

    // �������ֵ����ݣ���Numberһ����������֣�
    public void SetNumber(int number)
    {
        this.numberValue.text = number.ToString();
    }

    // ��ȡ���ֵ�����
    public int GetNumber()
    {
        return int.Parse(this.numberValue.text);
    }

    // ��ȡ�������ڸ���
    public MyGrid GetGrid()
    {
        return this.InGrid;
    }

    // �������ƶ���ָ��������
    public void MovetoGrid(MyGrid myGrid)
    {
        transform.SetParent(myGrid.transform); // ���õ�ǰ���ӵĸ��ڵ�

        this.GetGrid().SetNumber(null); // ����ǰ���ֶ�Ӧ�ĸ����е������ÿ�

        myGrid.SetNumber(this); // ��ָ��������������
        this.SetGrid(myGrid); // ����ǰ���������µĸ���
    }
}
