using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
/// <summary>
/// 单例模式基类 抽象类无法被new
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class BaseManager<T> where T:class 
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                //instance = new T();
                //利用反射得到无参私有构造函数 用来对象实例化
                Type type = typeof(T);
                ConstructorInfo info = type.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic,
                                    null,
                                    Type.EmptyTypes,
                                    null);
                
                if(info != null)
                {
                    instance = info.Invoke(null) as T;
                }
                else
                {
                    Debug.Log("没有对应的无参构造函数");
                }
            }
            return instance;
        }
    }
}
