using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 测试脚本
/// </summary>
public class Test4 : MonoBehaviour
{

    public GameObject hero1;

    public GameObject hero2;



    void OnGUI()
    {
        if (GUI.Button(new Rect(0,0,150,100),"开启按键输入管理器"))
        {
            InputKeysManager.Instance.SetActive(true);
        }

        if (GUI.Button(new Rect(0, 150, 150, 100), "关闭按键输入管理器"))
        {
            InputKeysManager.Instance.SetActive(false);
        }

        if (GUI.Button(new Rect(0, 300, 150, 100), "切换到英雄2"))
        {
            Destroy(hero1.GetComponent<Hero>());

            hero2.AddComponent<Hero>();

        }

        


    }







}
