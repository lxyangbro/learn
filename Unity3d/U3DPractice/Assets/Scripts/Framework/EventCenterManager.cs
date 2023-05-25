using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// 事件中心管理器
/// </summary>
public class EventCenterManager : SingletonPatternBase<EventCenterManager>
{
    //键表示命令的名字
    //值表示命令具体要执行的逻辑
    Dictionary<string, IEventInfo> eventsDictionary = new Dictionary<string, IEventInfo>();


    /// <summary>
    /// 监听命令
    /// </summary>
    /// <param name="command">命令</param>
    /// <param name="call">这条命令要干嘛</param>
    public void AddListener(object command,UnityAction call)
    {
        string key = command.GetType().Name + "_" + command.ToString();
        if(eventsDictionary.ContainsKey(key))
            (eventsDictionary[key] as EventInfo).action += call;
        else
            eventsDictionary.Add(key,new EventInfo(call));
    }

    public void AddListener<T>(object command,UnityAction<T> call)
    {
        string key = command.GetType().Name + "_" + command.ToString()+"_"+typeof(T).Name;
        if (eventsDictionary.ContainsKey(key))
            (eventsDictionary[key] as EventInfo<T>).action += call;
        else
            eventsDictionary.Add(key, new EventInfo<T>(call));
    }

    /// <summary>
    /// 发送没有参数的命令
    /// </summary>
    /// <param name="command">命令</param>
    public void Dispatch(object command)
    {
        string key = command.GetType().Name + "_" + command.ToString();
        if (eventsDictionary.ContainsKey(key))
            (eventsDictionary[key] as EventInfo).action?.Invoke();
    }

    /// <summary>
    /// 发送有一个参数的命令
    /// </summary>
    public void Dispatch<T>(object command,T parameter)
    {
        string key = command.GetType().Name + "_" + command.ToString()+"_"+typeof(T).Name;
        if (eventsDictionary.ContainsKey(key))
            (eventsDictionary[key] as EventInfo<T>).action?.Invoke(parameter);
    }



    /// <summary>
    /// 取消监听的命令
    /// </summary>
    public void RemoveListener(object command,UnityAction call)
    {
        string key = command.GetType().Name + "_" + command.ToString();
        if (eventsDictionary.ContainsKey(key))
            (eventsDictionary[key] as EventInfo).action -= call;
    }

    /// <summary>
    /// 移除一条命令的所有事件
    /// </summary>
    public void RemoveListeners(object command)
    {
        string key = command.GetType().Name + "_" + command.ToString();
        if (eventsDictionary.ContainsKey(key))
            (eventsDictionary[key] as EventInfo).action = null;
    }

    public void RemoveListener<T>(object command,UnityAction<T> call)
    {
        string key = command.GetType().Name + "_" + command.ToString()+"_"+typeof(T).Name;
        if (eventsDictionary.ContainsKey(key))
            (eventsDictionary[key] as EventInfo<T>).action -= call;
    }

    public void RemoveListeners<T>(object command)
    {
        string key = command.GetType().Name + "_" + command.ToString() + "_" + typeof(T).Name;
        if (eventsDictionary.ContainsKey(key))
            (eventsDictionary[key] as EventInfo<T>).action = null;
    }

    /// <summary>
    /// 移除事件中心的所有事件。可以考虑在切换场景时调用。
    /// </summary>
    public void RemoveAllListeners()
    {
        eventsDictionary.Clear();
    }

    private interface IEventInfo { }//用于里氏替换原则

    private class EventInfo<T>:IEventInfo
    {
        public UnityAction<T> action;

        public EventInfo(UnityAction<T> call)
        {
            action += call;
        }
    }





    private class EventInfo:IEventInfo
    {
        public UnityAction action;
        public EventInfo(UnityAction call)
        {
            action += call;
        }
    }







}
