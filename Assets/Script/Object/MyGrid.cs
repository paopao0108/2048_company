using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGrid : MonoBehaviour
{
    private Number number;
    // 判断是否有数字
    public bool IsHasNumber()
    {
        return number != null; // 当前格子没有数字，则返回false
    }

    // 获取格子上的数字
    public Number GetNumber()
    {
        return this.number;
    }

    // 设置格子上的数字
    public void SetNumber(Number number)
    {
        this.number = number;
    }
}
