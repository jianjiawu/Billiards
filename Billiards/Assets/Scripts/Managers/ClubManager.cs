using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClubManager : MonoBehaviour {

    //游戏对象
    GameObject WriteBall;
    //瞄准线
    public Transform Line;
    LineRenderer LR;
    //获得球桌游戏对象
    Transform Table;
    Transform Left;
    Transform Right;
    Transform Top;
    Transform Down;
    Vector3 TablePos;
    Vector3 TableLeftPos;
    Vector3 TableRightPos;
    Vector3 TableTopPos;
    Vector3 TableDownPos;
    //获得相机
    Camera m_cMainCam;
    Camera m_cUICam;

    Vector3 BallPos; 
    Vector3 ClubPos;
    Vector3 MousePos;

    private void Start()
    {
        //获取游戏对象
        WriteBall = GlobalHelper.g_GlobalLevel.WhiteBall;
        //相机
        m_cMainCam = Camera.main;
        //球桌
        Table = GlobalHelper.g_GlobalLevel.Table.transform;
        if (null == Right)
        {
            for (int i = 0; i < Table.childCount; i++)
            {
                if ("Right" == Table.GetChild(i).name)
                {
                    Right = Table.GetChild(i).transform;
                }
            }
        }
        if (null == Top)
        {
            for (int i = 0; i < Table.childCount; i++)
            {
                if ("Top" == Table.GetChild(i).name)
                {
                    Top = Table.GetChild(i).transform;
                }
            }
        }
        if (null == Down)
        {
            for (int i = 0; i < Table.childCount; i++)
            {
                if ("Down" == Table.GetChild(i).name)
                {
                    Down = Table.GetChild(i).transform;
                }
            }
        }
        if (null == Left)
        {
            for (int i = 0; i < Table.childCount; i++)
            {
                if ("Left" == Table.GetChild(i).name)
                {
                    Left = Table.GetChild(i).transform;
                }
            }
        }
        TableLeftPos = m_cMainCam.WorldToScreenPoint(Left.position);
        TableRightPos = m_cMainCam.WorldToScreenPoint(Right.position);
        TableTopPos = m_cMainCam.WorldToScreenPoint(Top.position);
        TableDownPos = m_cMainCam.WorldToScreenPoint(Down.position);

        //ClubPos = gameObject.transform.position;
        //Debug.Log(ClubPos);
        //瞄准线
        LR = Line.GetComponent<LineRenderer>();
    }

    private void Update()
    {
        BallPos = WriteBall.transform.position;
        ClubRot();
        //gameObject.transform.position = ClubPos;
    }


    void ClubRot()
    {
        MousePos = m_cMainCam.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            if (Input.mousePosition.x < TableRightPos.x
                && Input.mousePosition.x > TableLeftPos.x
                && Input.mousePosition.y > TableDownPos.y
                && Input.mousePosition.y < TableTopPos.y)
            {
                Vector3 dir = (MousePos - BallPos).normalized;
                //Debug.Log(dir);
                ClubPos = BallPos - dir;
                //Debug.Log(ClubPos);
            }
        }
        if(Input.GetMouseButton(0))
        {
            if (Input.mousePosition.x < TableRightPos.x
                && Input.mousePosition.x > TableLeftPos.x
                && Input.mousePosition.y > TableDownPos.y
                && Input.mousePosition.y < TableTopPos.y)
            {
                //Vector3 dir = (MousePos - BallPos).normalized;
                //Debug.Log(MousePos);
                MousePos.y = BallPos.y;
                //ClubPos = BallPos - dir;
                //ClubPos.y = BallPos.y;
                //Debug.Log(BallPos);
                //Debug.Log(ClubPos);
                if(Physics.Raycast(WriteBall.transform.position, MousePos - BallPos, out hit,100))
                {
                    if(hit.transform.tag == "Wall")
                    {
                        hitpos = hit.point;
                        //Debug.Log(MousePos);
                        //Debug.Log(hit.point);
                        pos = new Vector3((MousePos - BallPos).x, 0, (MousePos - BallPos).z);
                        setLine();
                    }   
                }  
            }
        }
    }

    Vector3 hitpos;
    RaycastHit hit;
    void setLine()
    {
        LR.startWidth = 0.3f;
        LR.startColor = Color.white;
        LR.endColor = Color.white;
        LR.SetPosition(0, BallPos);
        //LR.SetPosition(1,new Vector3(MousePos.x,0,MousePos.z));
        LR.SetPosition(1, new Vector3(hitpos.x, 0.5f, hitpos.z));
        //pos = new Vector3(MousePos.x, 0, MousePos.z);
    }
    Vector3 pos;
    private void OnGUI()
    {
        if (GUI.Button(new Rect(0, 100, 100, 100), "Press"))
        {
            Rigidbody rb = WriteBall.GetComponent<Rigidbody>();
            rb.AddForce(pos*50);
        }
    }
}
