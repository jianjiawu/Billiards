using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using AttTypeDefine;

public class BaseActor : MonoBehaviour {

    public static TestPlatzierenBall TPB;

    public static void OnStart()
    {
        //游戏对象
        GameObject Plane;
        Plane = Instantiate(Resources.Load("Prefabs/Plane")) as GameObject;
        GameObject WriteBall;
        WriteBall = Instantiate(Resources.Load("Prefabs/WriteBall")) as GameObject;
        GlobalHelper.g_GlobalLevel.Initialized(WriteBall, Plane);
        //UI
        GameObject UIM = new GameObject("UIManager");
        UIManager uim = UIM.AddComponent<UIManager>();
        uim.UI<UIHand>();
        //碰撞器
        GameObject SpCol;
        SpCol = Instantiate(Resources.Load("Prefabs/SpCol")) as GameObject;
        TPB = SpCol.GetComponent<TestPlatzierenBall>();
    }
}
