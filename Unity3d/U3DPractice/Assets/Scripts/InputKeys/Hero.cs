using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 玩家控制的英雄对象
/// </summary>
public class Hero : MonoBehaviour
{
    //移动方向
    Vector3 movementDirection;

    //移动速度
    public float movementSpeed=5;


    void Awake()
    {
        EventCenterManager.Instance.AddListener<KeyCode>(E_InputCommand.GetKey, CheckInputKeys);

        EventCenterManager.Instance.AddListener<KeyCode>(E_InputCommand.GetKeyUp, CheckInputKeyUp);
    }

    void CheckInputKeys(KeyCode key)
    {
        switch (key)
        {
            case KeyCode.W:
                movementDirection.Set(movementDirection.x,1,movementDirection.z);
                break;
            case KeyCode.S:
                movementDirection.Set(movementDirection.x, -1, movementDirection.z);
                break;
            case KeyCode.A:
                movementDirection.Set(-1,movementDirection.y,movementDirection.z);
                break;
            case KeyCode.D:
                movementDirection.Set(1,movementDirection.y,movementDirection.z);
                break;
        }
    }

    void CheckInputKeyUp(KeyCode key)
    {
        switch (key)
        {
            case KeyCode.W:
                movementDirection.Set(movementDirection.x, 0, movementDirection.z);
                break;
            case KeyCode.S:
                movementDirection.Set(movementDirection.x, 0, movementDirection.z);
                break;
            case KeyCode.A:
                movementDirection.Set(0,movementDirection.y,movementDirection.z);
                break;
            case KeyCode.D:
                movementDirection.Set(0, movementDirection.y, movementDirection.z);
                break;
        }
    }




    void OnDestroy()
    {
        EventCenterManager.Instance.RemoveListener<KeyCode>(E_InputCommand.GetKey, CheckInputKeys);

        EventCenterManager.Instance.RemoveListener<KeyCode>(E_InputCommand.GetKeyUp,CheckInputKeyUp);
    }


    void FixedUpdate()
    {
        transform.Translate(movementSpeed * movementDirection * Time.fixedDeltaTime);
    }








}
