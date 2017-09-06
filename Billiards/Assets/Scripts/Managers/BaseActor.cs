using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using AttTypeDefine;

public class BaseActor : MonoBehaviour {

    public static void OnStart()
    {
        GameObject obj;
        obj = Instantiate(Resources.Load("Prefabs/Plane")) as GameObject;
        GameObject _obj;
        _obj = Instantiate(Resources.Load("Prefabs/WriteBall")) as GameObject;
        GlobalHelper.g_GlobalLevel.Initialized(_obj, obj);
    }
}
