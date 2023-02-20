using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;

public class Number : MonoBehaviour
{
    private UnityEngine.UI.Image bg;
    private TextMeshPro numberValue;

    public MyGrid InGrid; // 数字所在的格子

    private void Awake()
    {
        bg = transform.GetComponent<UnityEngine.UI.Image>();
        numberValue = transform.Find("text").GetComponent<TextMeshPro>(); // 获取其子节点text的组件TextMeshPro
    }

    public void InitNumber(MyGrid myGrid)
    {
        myGrid.SetNumber(this); // 设置格子上的数字
        this.SetGrid(myGrid); // 设置数字所在格子
        this.SetNumber(4);
    }


    // 设置数字的格子
    public void SetGrid(MyGrid myGrid)
    {
        this.InGrid = myGrid;
    }

    // 设置数字的内容（给Number一个具体的数字）
    public void SetNumber(int number)
    {
        this.numberValue.text = number.ToString();
    }

    // 获取数字的内容
    public int GetNumber()
    {
        return int.Parse(this.numberValue.text);
    }

    // 获取数字所在格子
    public MyGrid GetGrid()
    {
        return this.InGrid;
    }

    // 将数字移动到指定格子里
    public void MovetoGrid(MyGrid myGrid)
    {
        transform.SetParent(myGrid.transform); // 设置当前格子的父节点

        this.GetGrid().SetNumber(null); // 将当前数字对应的格子中的数字置空

        myGrid.SetNumber(this); // 给指定格子设置数字
        this.SetGrid(myGrid); // 给当前数字设置新的格子
    }
}
