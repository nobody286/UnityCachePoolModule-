using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 延迟销毁对象（自身）脚本
/// </summary>
public class DelayRemove : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke("RemoveMe", 1f);
    }
    private void RemoveMe()
    {
        PoolMgr.Instance.PushObj(this.gameObject);
    }
}
