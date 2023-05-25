using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 注释
/// </summary>
public class Player
{

    Coroutine coroutine;

    public void Show()
    {
        //StartCoroutine(MyCoroutine());

        coroutine=MonoManager.Instance.StartCoroutine(MyCoroutine());

    }
    IEnumerator MyCoroutine()
    {
        while (true)
        {
            Debug.Log("协程执行中");
            yield return null;
        }
    }

    public void Hide()
    {
        MonoManager.Instance.StopCoroutine(coroutine);
    }

    public void HideAll()
    {
        MonoManager.Instance.StopAllCoroutines();
    }

    public void PrintUpdate()
    {
        MonoManager.Instance.AddUpdateListener(DebugUpdate);
    }

    public void StopPrintUpdate()
    {
        MonoManager.Instance.RemoveUpdateListener(DebugUpdate);
    }

    public void StopAllPrintUpdate()
    {
        MonoManager.Instance.RemoveAllUpdateListeners();
    }
    void DebugUpdate()
    {
        Debug.Log("Update");
    }




    public void PrintFixedUpdate()
    {
        MonoManager.Instance.AddFixedUpdateListener(DebugFixedUpdate);
    }

    public void StopFixedPrintUpdate()
    {
        MonoManager.Instance.RemoveFixedUpdateListener(DebugFixedUpdate);
    }

    public void StopAllPrintFixedUpdate()
    {
        MonoManager.Instance.RemoveAllFixedUpdateListeners();
    }

    void DebugFixedUpdate()
    {
        Debug.Log("FixedUpdate");
    }





    public void PrintLateUpdate()
    {
        MonoManager.Instance.AddLateUpdateListener(DebugLateUpdate);
    }

    public void StopLatePrintUpdate()
    {
        MonoManager.Instance.RemoveLateUpdateListener(DebugLateUpdate);
    }

    public void StopAllPrintLateUpdate()
    {
        MonoManager.Instance.RemoveAllLateUpdateListeners();
    }

    void DebugLateUpdate()
    {
        Debug.Log("LateUpdate");
    }

    public void StopAll()
    {
        MonoManager.Instance.RemoveAllListeners();
    }




}
