using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class AppConst
{
    public const bool DebugMode = false;                        //调试模式-用于内部测试

    /// <summary>
    /// 如果想删掉框架自带的例子，那这个例子模式必须要
    /// 关闭，否则会出现一些错误。
    /// </summary>
    public const bool ExampleMode = true;                       //例子模式 

    public const int TimerInterval = 1;
    public const int GameFrameRate = 30;                       //游戏帧频

    public const string AppName = "LuaFramework";               //应用程序名称
    public const string ExtName = ".unity3d";                   //资源扩展名
    public const string AppPrefix = AppName + "_";              //应用程序前缀

    public static string FrameworkRoot
    {
        get
        {
            return Application.dataPath + "/" + AppName;
        }
    }
}
