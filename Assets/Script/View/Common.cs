using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Common : MonoBehaviour
{
    // 显示（声明为虚方法可以被重写）
    public virtual void Show()
    {
        gameObject.SetActive(true);
    }

    // 隐藏
    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }
}
