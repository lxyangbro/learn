using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 测试脚本
/// </summary>
public class Test2 : MonoBehaviour
{
    Player player;

    void Awake()
    {
        player = new Player();


    }


    void OnGUI()
    {
        if (GUI.Button(new Rect(0,0,100,50),"开启协程"))
        {
            player.Show();
        }

        if (GUI.Button(new Rect(0, 80, 100, 50), "停止协程"))
        {
            player.Hide();
        }

        if (GUI.Button(new Rect(0, 160, 100, 50), "停止所有协程"))
        {
            player.HideAll();
        }







        if (GUI.Button(new Rect(150, 0, 150, 50), "添加Update事件"))
        {
            player.PrintUpdate();
        }

        if (GUI.Button(new Rect(150, 80, 150, 50), "移除Update事件"))
        {
            player.StopPrintUpdate();
        }

        if (GUI.Button(new Rect(150, 160, 150, 50), "移除所有Update事件"))
        {
            player.StopAllPrintUpdate();
        }



        if (GUI.Button(new Rect(400, 0, 200, 50), "添加FixedUpdate事件"))
        {
            player.PrintFixedUpdate();
        }

        if (GUI.Button(new Rect(400, 80, 200, 50), "移除FixedUpdate事件"))
        {
            player.StopFixedPrintUpdate();
        }

        if (GUI.Button(new Rect(400, 160, 200, 50), "移除所有FixedUpdate事件"))
        {
            player.StopAllPrintFixedUpdate();
        }



        if (GUI.Button(new Rect(650, 0, 200, 50), "添加LateUpdate事件"))
        {
            player.PrintLateUpdate();
        }

        if (GUI.Button(new Rect(650, 80, 200, 50), "移除LateUpdate事件"))
        {
            player.StopLatePrintUpdate();
        }

        if (GUI.Button(new Rect(650, 160, 200, 50), "移除所有LateUpdate事件"))
        {
            player.StopAllPrintLateUpdate();
        }

        if (GUI.Button(new Rect(650, 240, 200, 50), "移除所有事件"))
        {
            player.StopAll();
        }








    }




    


}
