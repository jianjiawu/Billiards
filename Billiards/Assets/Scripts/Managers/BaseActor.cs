using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using AttTypeDefine;

public class BaseActor : MonoBehaviour {

    public static TestPlatzierenBall TPB;

    public static void OnStart()
    {
        //加载球和球桌游戏对象，保存在结构体中
        GameObject Plane;
        Plane = Instantiate(Resources.Load("Prefabs/Plane")) as GameObject;
        GameObject WriteBall;
        WriteBall = Instantiate(Resources.Load("Prefabs/WriteBall")) as GameObject;
        GlobalHelper.g_GlobalLevel.Initialized(WriteBall, Plane);
        //加载指定UI
        GameObject UIM = new GameObject("UIManager");
        UIManager uim = UIM.AddComponent<UIManager>();
        uim.UI<UIHand>();
        UISlight uis = uim.UI<UISlight>();
        uis.transform.localPosition = new Vector3(0, 0, 0);
        UIPower uip = uim.UI<UIPower>();
        UIScore uisc = uim.UI<UIScore>();
        //碰撞器
        GameObject SpCol;
        SpCol = Instantiate(Resources.Load("Prefabs/SpCol")) as GameObject;
        TPB = SpCol.GetComponent<TestPlatzierenBall>();
    }
}
