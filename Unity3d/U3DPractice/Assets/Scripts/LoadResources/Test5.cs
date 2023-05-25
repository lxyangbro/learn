// using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 测试脚本
/// </summary>
public class Test5 : MonoBehaviour
{

    //正斜杠     /
    //反斜杠     \


    void OnGUI()
    {
        if (GUI.Button(new Rect(0,0,100,80),"加载单个资源"))
        {
            //    GameObject go=Resources.Load("Prefabs/Cube") as GameObject;
            //    Instantiate(go);

            //    GameObject go=Resources.Load("Prefabs/Cube", typeof(GameObject)) as GameObject;
            //    Instantiate(go);

            //GameObject go = Resources.Load<GameObject>("Prefabs/Cube");

            GameObject go = ResourcesManager.Instance.Load<GameObject>("Prefabs/Cube");

            Instantiate(go);
        }

        if (GUI.Button(new Rect(0, 100, 100, 80), "加载多个资源"))
        {
            //Object[] gos = Resources.LoadAll("Prefabs");

            //for (int i = 0; i < gos.Length; i++)
            //{
            //    Instantiate(gos[i] as GameObject);
            //}


            //Object[] gos = Resources.LoadAll("Prefabs", typeof(GameObject));

            //for (int i = 0; i < gos.Length; i++)
            //{
            //    Instantiate(gos[i] as GameObject);
            //}

            //GameObject[] gos= Resources.LoadAll<GameObject>("Prefabs");

            GameObject[] gos = ResourcesManager.Instance.LoadAll<GameObject>("Prefabs");

            for (int i = 0; i < gos.Length; i++)
            {
                Instantiate(gos[i]);
            }

        }

        if (GUI.Button(new Rect(150, 0, 150, 80), "异步加载单个资源"))
        {
            //StartCoroutine(LoadAsyncCoroutine());

            ResourcesManager.Instance.LoadAsync<GameObject>("Prefabs/Cube", (obj) =>
            {
                Instantiate(obj);
                Debug.Log("使用ResourcesManager加载完毕！");
            });


        
        }
        //IEnumerator LoadAsyncCoroutine()
        //{
        //    //开始异步加载
        //    ResourceRequest resourceRequest=Resources.LoadAsync<GameObject>("Prefabs/Cube");
        //    //等待资源加载完毕
        //    yield return resourceRequest;
        //    //资源加载完毕后执行的逻辑
        //    Instantiate(resourceRequest.asset);
        //    Debug.Log("异步加载完毕");
        //}








        }


}
