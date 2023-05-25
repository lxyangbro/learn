using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 按键输入管理器。
/// </summary>
public class InputKeysManager : SingletonPatternBase<InputKeysManager>
{
    //是否启用本脚本的功能，监听玩家按键输入。
    public bool IsActive { get; private set; }

    /// <summary>
    /// 是否激活按键监听
    /// 传入true，会激活按键监听，这样玩家通过按键输入管理器输入的操作才会生效。
    /// 传入false，会禁用按键监听，这样玩家通过按键输入管理器输入的操作就会无效。
    /// </summary>
    /// <param name="isActive"></param>
    public void SetActive(bool isActive)
    {
        IsActive = isActive;
        Debug.Log(isActive);
    }

    public InputKeysManager()
    {
        MonoManager.Instance.AddUpdateListener(CheckKeys);
    }



    void CheckKeys()
    {
        if (!IsActive) return;

        foreach (var item in Enum.GetValues(typeof(KeyCode)))
        {
            CheckKeysCode((KeyCode)item);
        }

        for (int i = 0; i <= 2; i++)
        {
            if (Input.GetMouseButtonDown(i))
            {
                EventCenterManager.Instance.Dispatch<int>(E_InputCommand.GetMouseButtonDown,i);
            }
            if (Input.GetMouseButtonUp(i))
            {
                EventCenterManager.Instance.Dispatch<int>(E_InputCommand.GetMouseButtonUp, i);
            }
            if (Input.GetMouseButton(i))
            {
                EventCenterManager.Instance.Dispatch<int>(E_InputCommand.GetMouseButton, i);
            }
        }
    }

    void CheckKeysCode(KeyCode key)
    {
        if (Input.GetKeyDown(key))
        {
            EventCenterManager.Instance.Dispatch<KeyCode>(E_InputCommand.GetKeyDown, key);
        }
        if (Input.GetKeyUp(key))
        {
            EventCenterManager.Instance.Dispatch<KeyCode>(E_InputCommand.GetKeyUp, key);
        }
        if (Input.GetKey(key))
        {
            EventCenterManager.Instance.Dispatch<KeyCode>(E_InputCommand.GetKey, key);
        }
    }







}
