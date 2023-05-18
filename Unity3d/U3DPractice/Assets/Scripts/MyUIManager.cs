using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyUIManager : MonoBehaviour
{
    private MyUIManager()
    {
    }

    private static MyUIManager instance;

    public static MyUIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<MyUIManager>();
                if (instance == null)
                {
                    Debug.Log("instance == null");
                    GameObject go = new GameObject("MyUIManager");
                    DontDestroyOnLoad(go);
                    instance = go.AddComponent<MyUIManager>();
                }
            }

            return instance;
        }
    }

    public void Show()
    {
        Debug.Log("显示面板");
    }

    public void Hide()
    {
        Debug.Log("隐藏面板");
    }
}