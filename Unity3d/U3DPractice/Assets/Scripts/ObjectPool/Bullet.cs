using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 子弹
/// </summary>
public class Bullet : MonoBehaviour
{
    public void OnSpawn()
    {
        Debug.Log("生成游戏对象！");
    }



    public void OnDespawn()
    {
        Debug.Log("回收游戏对象");
        transform.position = Vector3.zero;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }








}
