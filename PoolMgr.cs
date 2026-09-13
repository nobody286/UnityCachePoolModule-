using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 缓存池模块 管理器
/// </summary>
public class PoolMgr :BaseManager<PoolMgr>
{

    private  Dictionary<string , Stack<GameObject>> poolDic = new Dictionary<string, Stack<GameObject>>();
    private PoolMgr()
    {

    }

    /// <summary>
    /// 取东西的方法
    /// </summary>
    /// <param name="name">抽屉容器的名字</param>
    /// <returns>从缓存池取出的对象</returns>
    public GameObject GetObj(string name)
    {
        GameObject obj;
        //有抽屉 并且里面有对象 才直接去拿
        if ((poolDic.ContainsKey(name)) && poolDic[name].Count > 0)
        {
            //弹出栈中的对象 直接返回给外部使用
            obj = poolDic[name].Pop();
            //激活对象
            obj.SetActive(true);
        }
        //否则应该去创造
        else
        {
            //没有的时候通过资源加载实例化
            obj = GameObject.Instantiate(Resources.Load<GameObject>(name));
            //避免实例化出来的对象默认会在名字后面加一个(clone)
            //重命名过后方便往里面放
            obj.name = name;
        }
        return obj;
    }

    /// <summary>
    /// 往缓存池中放入对象
    /// </summary>
    /// <param name="name">抽屉（对象）的名字</param>
    /// <param name="obj">希望放入的对象</param>
    public void PushObj(GameObject obj)
    {
        //并不是直接移除 而是将对象失活 一会再用 用的时候激活
        //除了失活激活 还可以把对象放到屏幕外（摄像机）看不见的地方 为的是把对象隐藏起来
        obj.SetActive(false);

        if (!poolDic.ContainsKey(obj.name))
        {
            poolDic.Add(obj.name, new Stack<GameObject>());
        }
        //往抽屉中放对象
        poolDic[obj.name].Push(obj);

        //    //如果存在对应的抽屉容器 直接放
        //    if (poolDic.ContainsKey(name))
        //    {
        //        //往栈（抽屉）中 放入对象
        //        poolDic[name].Push(obj);
        //    }

        //    //否则需要先创建抽屉再放
        //    else
        //    { 
        //        poolDic.Add(name , new Stack<GameObject>());
        //        poolDic[name].Push(obj);
        //    }
    }
    /// <summary>
    /// 用于清除整个柜子当中的数据
    /// 主要是切换场景时使用
    /// </summary>
    public void ClearPool()
    {
        poolDic.Clear();
    }
}
