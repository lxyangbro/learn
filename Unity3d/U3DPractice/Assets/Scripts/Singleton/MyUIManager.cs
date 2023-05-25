using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 我的UI管理器
/// </summary>
public class MyUIManager:SingletonPatternMonoAutoBase_DontDestroyOnLoad<MyUIManager>
{
    private MyUIManager() { }

    public void Show()
    {
        Debug.Log("显示面板");
    }

    public void Hide()
    {
        Debug.Log("隐藏面板");
    }



}
