using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 策划
/// </summary>
public class Cube : MonoBehaviour
{

    void Awake()
    {
        EventCenterManager.Instance.AddListener(E_EventCommand.Work, Write);

        EventCenterManager.Instance.AddListener(E_EventCommand.Fire, () => {
            Debug.Log("哎哟，好烫哦，救命啊！");
        
        });

        EventCenterManager.Instance.AddListener<int>(E_EventCommand.LevelUp, LevelUp);
    }

    


        
    public void Write()
    {
        transform.position += Vector3.right;
        Debug.Log("我是策划，我在写策划案了，哈哈哈！");
    }

    public void LevelUp(int a)
    {
        Debug.Log($"我是策划，我升了{a}级");
    }

    //可以使用自定义的类，也可以使用元组来处理多个参数的情况。
    public void Show(MyInfo myInfo)
    {
        Debug.Log($"int型的值是{myInfo.a},float型的值是{myInfo.b},double型的值是{myInfo.c}");
    }

    void OnDestroy()
    {
        EventCenterManager.Instance.RemoveListener(E_EventCommand.Work, Write);

        EventCenterManager.Instance.RemoveListener(E_EventCommand.Fire, () => {
            Debug.Log("哎哟，好烫哦，救命啊！");

        });

        EventCenterManager.Instance.RemoveListener<int>(E_EventCommand.LevelUp, LevelUp);
    }




}
