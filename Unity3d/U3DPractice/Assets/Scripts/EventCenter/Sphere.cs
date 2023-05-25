using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 程序员
/// </summary>
public class Sphere : MonoBehaviour
{
    void Awake()
    {
        EventCenterManager.Instance.AddListener(E_EventCommand.Work, Code);

        EventCenterManager.Instance.AddListener(E_EventCommand.Fire, () => {
            Debug.Log("不怕！爷我的火抗比较高，我免疫火焰伤害！");
        });

        EventCenterManager.Instance.AddListener<int>(E_EventCommand.LevelUp, LevelUp);

    }



    public void Code()
    {
        transform.localScale += new Vector3(1, 0, 0);
        Debug.Log("我是程序员，我在写代码了，嘻嘻嘻！");
    }

    public void LevelUp(int a)
    {
        Debug.Log($"我是程序员，我升了{a+1}级");
    }







    void OnDestroy()
    {
        EventCenterManager.Instance.RemoveListener(E_EventCommand.Work, Code);

        EventCenterManager.Instance.RemoveListener(E_EventCommand.Fire, () => {
            Debug.Log("不怕！爷我的火抗比较高，我免疫火焰伤害！");

        });

        EventCenterManager.Instance.RemoveListener<int>(E_EventCommand.LevelUp, LevelUp);
    }




}
