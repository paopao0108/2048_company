using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;

public class Number : MonoBehaviour
{
    private UnityEngine.UI.Image bg;
    private TextMeshProUGUI numberValue;

    private MyGrid InGrid; // �������ڵĸ���

    private void Awake()
    {
        bg = transform.GetComponent<UnityEngine.UI.Image>();
        numberValue = transform.Find("text").GetComponent<TextMeshProUGUI>(); // ��ȡ���ӽڵ�text�����TextMeshPro
    }

    public void InitNumber(MyGrid myGrid)
    {
        myGrid.SetNumber(this); // ���ø����ϵ�����
        this.SetGrid(myGrid); // �����������ڸ���
        this.SetNumber(2);
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
        transform.localPosition = Vector3.zero;

        this.GetGrid().SetNumber(null); // ����ǰ���ֶ�Ӧ�ĸ����е������ÿ�

        myGrid.SetNumber(this); // ��ָ��������������
        this.SetGrid(myGrid); // ����ǰ���������µĸ���
    }

    public bool IsMerge(MyGrid myGrid)
    {
        return int.Parse(myGrid.GetNumber().numberValue.text) == GetNumber();
        //return myGrid.GetNumber().numberValue.text == numberValue.text;
    }

    public void NumberMerge()
    {
        SetNumber(GetNumber() * 2);
    }
}
