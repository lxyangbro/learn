using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// 测试脚本
/// </summary>
public class Test : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {

            MyUIManager.Instance.Show();

            MyUIManager.Instance.Hide();



            


        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            SceneManager.LoadScene("Singleton2");


        }


    }


    private void OnDestroy()
    {
        if(MyUIManager.IsExisted)
            MyUIManager.Instance.Show();
    }





}
