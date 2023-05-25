using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 测试脚本
/// </summary>
public class UITest : MonoBehaviour
{
    //要显示的面板
    GameObject panel;

    //生成在场景上的面板游戏对象
    //GameObject go;


    void Awake()
    {
        panel= Resources.Load<GameObject>("Panels/TitlePanel");

    }


    void OnGUI()
    {
        if (GUI.Button(new Rect(0,0,100,80),"显示面板"))
        {
            //panel=Resources.Load<GameObject>("Panels/TitlePanel");
            //go=Instantiate(panel);
            //go.transform.SetParent(GameObject.Find("Canvas").transform,false);

            UIManager.Instance.ShowPanel(panel);

        }

        if (GUI.Button(new Rect(0, 100, 100, 80), "隐藏面板"))
        {
            //Destroy(go);

            //UIManager.Instance.HidePanel(panel);

            UIManager.Instance.HidePanel("TitlePanel");


        }

        if (GUI.Button(new Rect(0, 200, 150, 80), "判断面板是否显示了"))
        {
            //Debug.Log(UIManager.Instance.IsPanelShowed(panel));

            Debug.Log(UIManager.Instance.IsPanelShowed("TitlePanel"));


        }









    }












}
