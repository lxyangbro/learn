using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 测试脚本
/// </summary>
public class Test3 : MonoBehaviour
{

    void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 120, 50), "发送命令1"))
        {
            //GameObject go = GameObject.Find("Cube");
            //go.GetComponent<Cube>().Write();

            //GameObject go2 = GameObject.Find("Sphere");
            //go2.GetComponent<Sphere>().Code();

            //GameObject go3 = GameObject.Find("Capsule");
            //go3.GetComponent<Capsule>().Draw();

            EventCenterManager.Instance.Dispatch(E_EventCommand.Work);
        }

        if (GUI.Button(new Rect(0, 80, 150, 50), "移除命令1的所有事件"))
        {
            EventCenterManager.Instance.RemoveListeners(E_EventCommand.Work);


        }



        if (GUI.Button(new Rect(0, 200, 200, 50), "发送带有一个参数的命令"))
        {
            EventCenterManager.Instance.Dispatch<int>(E_EventCommand.LevelUp,1);
        }

        if (GUI.Button(new Rect(0, 300, 200, 50), "移除LevelUp命令的所有事件"))
        {
            EventCenterManager.Instance.RemoveListeners<int>(E_EventCommand.LevelUp);
        }





        if (GUI.Button(new Rect(200, 0, 120, 50), "发送命令2"))
        {
            EventCenterManager.Instance.Dispatch(E_EventCommand.Fire);
        }

        if (GUI.Button(new Rect(200, 80, 150, 50), "移除命令2的所有事件"))
        {

            EventCenterManager.Instance.RemoveListeners(E_EventCommand.Fire);
        }


    }

   void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            StopwatchUtility.PrintTime(() => {

                //Type type = "开工咯，好耶".GetType();

                //Type type = typeof(string);

                new GameObject();

            },10000);
        }
    }






    Father father = new Son1();

    Father father2 = new Son2();


    ICreature iCreature = new Human();

    ICreature iCreature2 = new Fish();


    
}





public class Father { }

public class Son1 :Father{ }

public class Son2 :Father{ }




interface ICreature { }

public class Human :ICreature{ }

public class Fish:ICreature { }








