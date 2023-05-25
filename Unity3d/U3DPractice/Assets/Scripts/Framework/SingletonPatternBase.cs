using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 不继承MonoBehaviour的单例模式基类
/// 作用：继承了这个类的类自带单例模式
/// </summary>
public class SingletonPatternBase<T> where T:SingletonPatternBase<T>//泛型T必须为这个类本身或者是它的子类
{
    //构造方法私有化，防止外部new对象。
    protected SingletonPatternBase() { }

    //线程锁。当多线程访问时，同一时刻仅允许一个线程访问。
    private static object locker = new object();

    //提供一个属性给外部访问，这个属性就相当于是单例对象。
    //volatile关键字修饰的字段，当多个线程都对它进行修改时，可以确保这个字段在任何时刻呈现的都是最新的值。
    private volatile static T instance;
    public static T Instance
    {
        get
        {

            if (instance == null)
            {
                lock (locker)
                {
                    //保证对象的唯一性。
                    if (instance == null)
                    {
                        instance = Activator.CreateInstance(typeof(T), true) as T;//使用反射，调用无参构造方法创建对象。
                    }
                }
            }




            return instance;
        }
    }









}
