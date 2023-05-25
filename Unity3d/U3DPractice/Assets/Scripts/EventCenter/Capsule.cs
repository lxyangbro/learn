// using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 美术人员
/// </summary>
public class Capsule : MonoBehaviour
{

    void Awake()
    {
        EventCenterManager.Instance.AddListener(E_EventCommand.Work, Draw);

        EventCenterManager.Instance.AddListener(E_EventCommand.Fire, () => {
            Debug.Log("呱呱呱");
        });

        EventCenterManager.Instance.AddListener<int>(E_EventCommand.LevelUp, LevelUp);

    }


    public void Draw()
    {
        transform.Rotate(Vector3.forward, 5f);
        Debug.Log("我是美术人员，我在画画了，诶嘿，嘿嘿。");
    }

    public void LevelUp(int a)
    {
        Debug.Log($"我是美术人员，我升了{a + 2}级");
    }




    void OnDestroy()
    {
        EventCenterManager.Instance.RemoveListener(E_EventCommand.Work, Draw);

        EventCenterManager.Instance.RemoveListener(E_EventCommand.Fire, () => {
            Debug.Log("呱呱呱");

        });

        EventCenterManager.Instance.RemoveListener<int>(E_EventCommand.LevelUp, LevelUp);

    }




}
