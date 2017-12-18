using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitManager : MonoBehaviour {

    GameObject UIMgr;
    UIManager UIM;
    UISlight UIS;
    public Camera m_cMainCam;
    public Camera m_cUICam;

    float bili;
    float X;
    float Y;

    //修改击球点
    bool bChangeBall = false;
    bool bChangeClub = false;
    // Use this for initialization
    void Start () {
        UIMgr = GameObject.Find("UIManager");
        UIM = UIMgr.GetComponent<UIManager>();
        UIS = UIM.UI<UISlight>(false);
        //获得相机
        m_cMainCam = Camera.main;
        GameObject uiroot = GameObject.Find("UI Root");
        m_cUICam = NGUITools.FindCameraForLayer(uiroot.layer);
        C = UIS.m_oLine.transform.position - new Vector3(UIS.m_oClub.transform.position.x - 10, UIS.m_oClub.transform.position.y - 7.8f, UIS.m_oClub.transform.position.z);
    }

    //初始线
    Vector3 C;
    Vector3 pos;
    //点击屏幕位置
    Vector3 MousePos;
    // Update is called once per frame
    void Update () {

        MousePos = m_cUICam.ViewportToWorldPoint(m_cMainCam.WorldToViewportPoint(m_cMainCam.ScreenToWorldPoint(Input.mousePosition)));
        if (bChangeClub == true)
        {
            if (MousePos.x > UIS.m_oClub.transform.position.x - 5 &&
                MousePos.x < UIS.m_oClub.transform.position.x + 5 &&
                MousePos.y > UIS.m_oClub.transform.position.y - 7.8f &&
                MousePos.y < UIS.m_oClub.transform.position.y + 7.8f)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    //点击之前两者位置
                    Vector3 A = UIS.m_oLine.transform.position - new Vector3(UIS.m_oClub.transform.position.x - 10, UIS.m_oClub.transform.position.y - 7.8f, UIS.m_oClub.transform.position.z);
                    //Vector3 A = OriPos;
                    //点击点与A的位置
                    Vector3 B = MousePos - new Vector3(UIS.m_oClub.transform.position.x - 10, UIS.m_oClub.transform.position.y - 7.8f, UIS.m_oClub.transform.position.z);
                    //点击点与线的夹角
                    float AngleAB = Vector3.Angle(A, B);
                    //点击点与初始线的夹角
                    float AngleBC = Vector3.Angle(C, B);
                    //线移动角度
                    float AngleAC = Vector3.Angle(A, C);
                    Debug.Log(AngleAB);
                    Debug.Log(AngleBC);
                    //Debug.Log(UIS.m_oLine.transform.position);
                    if (AngleBC < AngleAC)
                    {
                        AngleAB = -AngleAB;
                    }
                    UIS.m_oLine.transform.RotateAround(new Vector3(UIS.m_oClub.transform.position.x - 10, UIS.m_oClub.transform.position.y - 7.8f, UIS.m_oClub.transform.position.z), new Vector3(0, 0, 1), AngleAB);
                    FroceY = AngleAB;
                }
            }
        }

        if(bChangeBall == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if(Vector3.Distance(MousePos, UIS.m_oBack.transform.position)<=7)
                {
                    //UIS.m_oFront.transform.position = Input.mousePosition;
                    //点击屏幕位置
                    pos = m_cMainCam.ScreenToWorldPoint(Input.mousePosition);
                    //视口坐标
                    Vector3 viewpos = m_cMainCam.WorldToViewportPoint(pos);
                    //UI世界坐标
                    UIS.m_oFront.transform.position = m_cUICam.ViewportToWorldPoint(viewpos);
                    X = (pos.x - UIS.m_oBack.transform.position.x) / 7;
                    Y = (pos.y - UIS.m_oBack.transform.position.y) / 7;
                }
            }
            else if (Input.GetMouseButton(0))
            {
                //点击屏幕位置
                pos = m_cMainCam.ScreenToWorldPoint(Input.mousePosition);
                if (Vector3.Distance(MousePos, UIS.m_oBack.transform.position) <= 7)
                {
                    //视口坐标
                    Vector3 viewpos = m_cMainCam.WorldToViewportPoint(pos);
                    //UI世界坐标
                    UIS.m_oFront.transform.position = m_cUICam.ViewportToWorldPoint(viewpos);
                }
                else
                {
                    //Vector3 back = UIS.m_oBack.transform.position;
                    //Debug.Log((pos - back).normalized);
                    //Vector3 Viewpos = m_cMainCam.WorldToViewportPoint(back + (pos - back).normalized * 7);
                    //UIS.m_oFront.transform.position = m_cUICam.ViewportToWorldPoint(Viewpos);
                }
                //bili = Vector3.Distance(UIS.m_oFront.transform.position, UIS.m_oBack.transform.position)/7;
            }
            else if (Input.GetMouseButtonUp(0))
            {

            }
        }
	}


    float FroceY;
    bool bUI;
    bool bCanChange;

}
