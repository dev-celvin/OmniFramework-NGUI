using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.IO;

public class GameManager : Manager
{
    protected static bool initialize = false;
    private List<string> downloadFiles = new List<string>();

    /// <summary>
    /// 初始化游戏管理器
    /// </summary>
    void Awake()
    {
        Init();
    }

    /// <summary>
    /// 初始化
    /// </summary>
    void Init()
    {
        DontDestroyOnLoad(gameObject);  //防止销毁自己

        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Application.targetFrameRate = AppConst.GameFrameRate;
    }

    /// <summary>
    /// 初始化GUI
    /// </summary>
    public void InitGui()
    {
        string name = "GUI";
        GameObject gui = GameObject.Find(name);
        if (gui != null) return;

        GameObject prefab = Util.LoadPrefab(name);
        gui = Instantiate(prefab) as GameObject;
        gui.name = name;
    }

    /// <summary>
    /// 资源初始化结束
    /// </summary>
    public void OnResourceInited()
    {
        initialize = true;                          //初始化完 
    }


    /// <summary>
    /// 析构函数
    /// </summary>
    void OnDestroy()
    {
        Debug.Log("~GameManager was destroyed");
    }
}
