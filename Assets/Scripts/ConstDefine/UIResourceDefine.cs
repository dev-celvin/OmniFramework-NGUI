using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum WindowID
{
    WindowID_Invaild = 0,
    WindowID_MainMenu,
    WindowID_Access,
    WindowID_UserCenter,
    WindowID_Shop,
    WindowID_Game,
    WindowID_Anim,
    WindowID_Arena,
    WindowID_Introduction,
    WindowID_Tip,
    WindowID_AR,
    WindowID_GainBox,
    WindowID_Reward,
    WindowID_Splash,
}

public enum UIWindowType
{
    Normal,    // 可推出界面(UIMainMenu,UIRank等)
    Fixed,     // 固定窗口(UITopBar等)
    PopUp,     // 模式窗口
}

public enum UIWindowShowMode
{
    DoNothing,
    HideOther,     // 闭其他界面
    NeedBack,      // 点击返回按钮关闭当前,不关闭其他界面(需要调整好层级关系)
    NoNeedBack,    // 关闭TopBar,关闭其他界面,不加入backSequence队列
}

public enum UIWindowColliderMode
{
    None,      // 显示该界面不包含碰撞背景
    Normal,    // 碰撞透明背景
    WithBg,    // 碰撞非透明背景
}

public class UIResourceDefine
{
    public static Dictionary<WindowID, string> windowPrefabPath = new Dictionary<WindowID, string>()
    {
        { WindowID.WindowID_MainMenu, "UIMainMenu" },
        { WindowID.WindowID_Access, "UIAccess"},
        { WindowID.WindowID_UserCenter, "UIUserCenter"},
        { WindowID.WindowID_Game, "UIGame"},
        { WindowID.WindowID_Shop, "UIShop"},
        { WindowID.WindowID_Anim, "UIAnim"},
        { WindowID.WindowID_Introduction, "UIIntroduction"},
        { WindowID.WindowID_Tip, "UITip"},
        { WindowID.WindowID_Arena, "UIArena"},
        { WindowID.WindowID_AR, "UIAR"},
        { WindowID.WindowID_GainBox, "UIGainBox"},
        { WindowID.WindowID_Reward, "UIReward"},
        { WindowID.WindowID_Splash, "UISplash"},
    };

    public static string UIPrefabPath = "UIPrefabs/";

    public static Dictionary<int, float> gScaleDic = new Dictionary<int, float>() {
        {6,  16f/9},
        {1, 4f/3},
    };

    public const string PTexturePath = "Texture/Products/";
    public const string GTexturePath = "Texture/Games/";

}
