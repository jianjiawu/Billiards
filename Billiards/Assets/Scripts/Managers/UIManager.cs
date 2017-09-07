using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.Text;

public class UIManager : MonoBehaviour {

    string PrefabRoute = "UI/";

    GameObject uiroot;
    GameObject UIRoot
    {
        get
        {
            if(null == uiroot)
            {
                uiroot = GameObject.Find("UI Root");
                if(null == uiroot)
                {
                    StringBuilder sb = new StringBuilder(PrefabRoute);
                    sb.Append("UI Root");
                    uiroot = Instantiate(Resources.Load(sb.ToString())) as GameObject;
                    uiroot.name = "UI Root";
                }
            }
            return uiroot;
        }
    }

    private GameObject anchor;
    public GameObject ANCHOR
    {
        get
        {
            if (null == anchor)
            {
                for (int i = 0; i < UIRoot.transform.childCount; i++)
                {
                    if ("Anchor" == UIRoot.transform.GetChild(i).name)
                    {
                        anchor = UIRoot.transform.GetChild(i).gameObject;
                    }
                }
            }
            return anchor;
        }
    }

    public T UI<T>(bool bLoad = true) where T:Component
    {
        Type t = typeof(T);
        StringBuilder sb = new StringBuilder(PrefabRoute);
        sb.Append(t.Name);
        T rel = null;
        if (bLoad)
        {
            UnityEngine.Object obj = Resources.Load(sb.ToString());
            GameObject _obj = Instantiate(obj) as GameObject;
            _obj.name = obj.name;
            _obj.transform.parent = ANCHOR.transform;
            _obj.transform.position = Vector3.zero;
            _obj.transform.rotation = Quaternion.identity;
            _obj.transform.localScale = Vector3.one;
            rel = _obj.AddComponent<T>();
        }
        else
        {
            for (int i = 0; i < ANCHOR.transform.childCount; i++)
            {
                if (t.Name == ANCHOR.transform.GetChild(i).name)
                {
                    rel = ANCHOR.transform.GetChild(i).GetComponent<T>();
                }
            }
        }
        return rel;
    }
}
