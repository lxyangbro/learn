using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
/// <summary>
/// 测试脚本
/// </summary>
#if UNITY_EDITOR
public class SceneTest
{
    [MenuItem("我的菜单/同步切换场景/重新切换到当前场景")]
    static void Method1()
    {
        LoadSceneManager.Instance.LoadActiveScene();

    }

    [MenuItem("我的菜单/同步切换场景/切换到下一个场景")]
    static void Method2()
    {
        LoadSceneManager.Instance.LoadNextScene(true);

    }

    [MenuItem("我的菜单/同步切换场景/切换到上一个场景")]
    static void Method3()
    {
        LoadSceneManager.Instance.LoadPreviousScene(true);

    }

    [MenuItem("我的菜单/异步切换场景/切换到场景1")]
    static void Method4()
    {
        LoadSceneManager.Instance.LoadSceneAsync("Scene1", (obj) => {
            Debug.Log("加载进度是："+obj*100+"%");
        }, (obj) => {
            Debug.Log("加载完成了！");
        });

    }

    [MenuItem("我的菜单/异步切换场景/切换到场景2")]
    static void Method5()
    {
        LoadSceneManager.Instance.LoadSceneAsync("Scene2", (obj) => {
            Debug.Log("加载进度是：" + obj * 100 + "%");
        }, (obj) => {
            Debug.Log("加载完成了！");
        });

    }

    [MenuItem("我的菜单/异步切换场景/切换到场景3")]
    static void Method6()
    {
        LoadSceneManager.Instance.LoadSceneAsync("Scene3", (obj) => {
            Debug.Log("加载进度是：" + obj * 100 + "%");
        }, (obj) => {
            Debug.Log("加载完成了！");
        });

    }

    [MenuItem("我的菜单/叠加式加载场景/加载场景2")]
    static void Method7()
    {
        SceneManager.LoadScene("Scene2",LoadSceneMode.Additive);
    }

    [MenuItem("我的菜单/叠加式加载场景/实例化一个Cube")]
    static void Method8()
    {
        GameObject go = Resources.Load<GameObject>("Prefabs/Cube");
        Object.Instantiate(go);
    }

    [MenuItem("我的菜单/叠加式加载场景/把场景1设置为活动场景")]
    static void Method9()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Scene1"));
    }

    [MenuItem("我的菜单/叠加式加载场景/把场景2设置为活动场景")]
    static void Method10()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Scene2"));
    }

    [MenuItem("我的菜单/叠加式加载场景/销毁场景2")]
    static void Method11()
    {
        SceneManager.UnloadSceneAsync("Scene2");
    }



}
#endif