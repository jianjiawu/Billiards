using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlatzierenBall : MonoBehaviour {

    GameObject UIMgr;
    UIManager UIM;
    UIHand UIh;
    GameObject DP;
    //获得球游戏对象
    GameObject WhiteBall;
    GameObject HandUI;
    GameObject SpCol;
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
    //尺寸
    float size;
    //获得相机
    Camera m_cMainCam;
    Camera m_cUICam;
    //设置bool值控制开球
    bool bIsFirstPlatzieren =true;
    //设置bool值控制自由球
    public bool bFreisto =false;
    bool bCanPlatzieren = false;

    public void OnStart()
    {
        gameObject.SetActive(true);
    }

    private void Start()
    {
        //获得游戏对象
        GetBallAndTable();
        //碰撞器
        //SpCol = Instantiate(Resources.Load("Prefabs/SpCol")) as GameObject;
        //SpCol.SetActive(false);
        SpCol = gameObject;
        //球桌坐标转换
        TablePos = m_cMainCam.WorldToScreenPoint(Table.position);
        //Vector3 pos = Left.TransformPoint(Left.position);
        TableLeftPos = m_cMainCam.WorldToScreenPoint(Left.position);
        TableRightPos = m_cMainCam.WorldToScreenPoint(Right.position);
        TableTopPos = m_cMainCam.WorldToScreenPoint(Top.position);
        TableDownPos = m_cMainCam.WorldToScreenPoint(Down.position);
        //设置尺寸
        size = WhiteBall.GetComponent<SphereCollider>().radius + 0.1f;
    }

    //获得游戏对象
    void GetBallAndTable()
    {
        //获得相机
        m_cMainCam = Camera.main;
        GameObject uiroot = GameObject.Find("UI Root");
        m_cUICam = NGUITools.FindCameraForLayer(uiroot.layer);
        //获得母球
        WhiteBall = GlobalHelper.g_GlobalLevel.WhiteBall;
        //获得球桌
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
        //获得UI
        //if(null == HandUI)
        //{
        //    for(int i=0;i<gameObject.transform.childCount;i++)
        //    {
        //        if("Hand" == gameObject.transform.GetChild(i).name)
        //        {
        //            HandUI = gameObject.transform.GetChild(i).gameObject;
        //        }
        //    }
        //}
        UIMgr = GameObject.Find("UIManager");
        UIM = UIMgr.GetComponent<UIManager>();
        UIh = UIM.UI<UIHand>(false);
        if (DP == null)
        {
            for (int i = 0; i < UIh.gameObject.transform.childCount; i++)
            {
                if (UIh.gameObject.transform.GetChild(i).name == "DontPush")
                {
                    DP = UIh.gameObject.transform.GetChild(i).gameObject;
                }
            }
        }
        if (HandUI == null)
        {
            for (int i = 0; i < UIh.gameObject.transform.childCount; i++)
            {
                if (UIh.gameObject.transform.GetChild(i).name == "Hand")
                {
                    HandUI = UIh.gameObject.transform.GetChild(i).gameObject;
                }
            }
        }
    }

    // Update is called once per frame
    void Update () {
        if(bIsFirstPlatzieren)
        {
            //开球
            Anstossen();
            DP.transform.position = HandUI.transform.position;
        }
        if(bFreisto)
        {
            //自由球
            Freisto();
            DP.transform.position = HandUI.transform.position;
        }
	}

    //开球逻辑
    void Anstossen()
    { 
        if(Input.GetMouseButtonDown(0))
        {
            if (Input.mousePosition.x < (TablePos.x + TableLeftPos.x) / 2 - size
                && Input.mousePosition.x > TableLeftPos.x + size
                && Input.mousePosition.y > TableDownPos.y + size
                && Input.mousePosition.y < TableTopPos.y - size)
            {
                //Vector3 pos = m_cMainCam.ScreenToWorldPoint(Input.mousePosition);
                //WhiteBall.transform.position = new Vector3(pos.x, 0.5f, pos.z);
                //WhiteBall.SetActive(true);
                //点击屏幕位置
                Vector3 pos = m_cMainCam.ScreenToWorldPoint(Input.mousePosition);
                //世界坐标
                Vector3 BallPos = SpCol.transform.position = new Vector3(pos.x, 0.5f, pos.z);
                //Debug.Log(pos);
                //Debug.Log(BallPos);
                //视口坐标
                Vector3 viewpos = m_cMainCam.WorldToViewportPoint(pos);
                Vector3 Viewpos = m_cMainCam.WorldToViewportPoint(BallPos);
                //UI世界坐标
                HandUI.transform.position = m_cUICam.ViewportToWorldPoint(Viewpos);
                //Debug.Log(WhiteBall.transform.position);
                //Debug.Log(m_cUICam.ViewportToWorldPoint(m_cMainCam.WorldToViewportPoint(BallPos)));
                HandUI.SetActive(true);
            }
            else
            {
                return;
            }
        }
        if(Input.GetMouseButton(0))
        {
            //合理区域
            Vector3 pos = m_cMainCam.ScreenToWorldPoint(Input.mousePosition);
            if (Input.mousePosition.x < (TablePos.x + TableLeftPos.x) / 2 - size
                 && Input.mousePosition.x > TableLeftPos.x + size
                 && Input.mousePosition.y > TableDownPos.y + size
                && Input.mousePosition.y < TableTopPos.y - size)
            {
                //WhiteBall.transform.position = new Vector3(pos.x, 0.5f, pos.z);
                //世界坐标
                Vector3 BallPos = SpCol.transform.position = new Vector3(pos.x, 0.5f, pos.z);
                //Vector3 BallPos = new Vector3(pos.x,pos.y,0);
                //视口坐标
                Vector3 viewpos = m_cMainCam.WorldToViewportPoint(BallPos);
                //UI世界坐标
                HandUI.transform.position = m_cUICam.ViewportToWorldPoint(viewpos);
            }
            //超出右边
            if (Input.mousePosition.x > (TablePos.x + TableLeftPos.x) / 2 - size
                && Input.mousePosition.y > TableDownPos.y + size
                && Input.mousePosition.y < TableTopPos.y - size)
            {
                //坐标转换
                //Vector3 Pos = new Vector3((Table.transform.position.x + Left.transform.position.x) / 2 - size, 0.5f, pos.z) ;
                //Vector3 ViewPos = m_cMainCam.WorldToViewportPoint(Pos);
                //WhiteBall.transform.position = new Vector3((Table.transform.position.x + Left.transform.position.x) / 2, 0.5f, pos.z);
                //世界坐标
                Vector3 BallPos = SpCol.transform.position = new Vector3((Table.transform.position.x + Left.transform.position.x) / 2 - size, 0.5f, pos.z);
                //视口坐标
                Vector3 viewpos = m_cMainCam.WorldToViewportPoint(BallPos);
                //UI世界坐标
                HandUI.transform.position = m_cUICam.ViewportToWorldPoint(viewpos);
            }
            //超出左边
            if(Input.mousePosition.x < TableLeftPos.x + size
               && Input.mousePosition.y > TableDownPos.y + size
               && Input.mousePosition.y < TableTopPos.y - size)
            {
                //WhiteBall.transform.position = new Vector3(Left.transform.position.x, 0.5f, pos.z);
                //世界坐标
                Vector3 BallPos = SpCol.transform.position = new Vector3(Left.transform.position.x + size, 0.5f, pos.z);
                //视口坐标
                Vector3 viewpos = m_cMainCam.WorldToViewportPoint(BallPos);
                //UI世界坐标
                HandUI.transform.position = m_cUICam.ViewportToWorldPoint(viewpos);
            }
            //超出下边
            if(Input.mousePosition.y < TableDownPos.y + size
                && Input.mousePosition.x < (TablePos.x + TableLeftPos.x) / 2 - size
                && Input.mousePosition.x > TableLeftPos.x + size)
            {
                //WhiteBall.transform.position = new Vector3(pos.x, 0.5f, Down.transform.position.z);
                //世界坐标
                Vector3 BallPos = SpCol.transform.position = new Vector3(pos.x, 0.5f, Down.transform.position.z + size);
                //视口坐标
                Vector3 viewpos = m_cMainCam.WorldToViewportPoint(BallPos);
                //UI世界坐标
                HandUI.transform.position = m_cUICam.ViewportToWorldPoint(viewpos);
            }
            //超出上边
            if(Input.mousePosition.y > TableTopPos.y - size
                && Input.mousePosition.x < (TablePos.x + TableLeftPos.x) / 2 - size
                && Input.mousePosition.x > TableLeftPos.x + size)
            {
                //WhiteBall.transform.position = new Vector3(pos.x, 0.5f, Top.transform.position.z);
                //世界坐标
                Vector3 BallPos = SpCol.transform.position = new Vector3(pos.x, 0.5f, Top.transform.position.z - size);
                //视口坐标
                Vector3 viewpos = m_cMainCam.WorldToViewportPoint(BallPos);
                //UI世界坐标
                HandUI.transform.position = m_cUICam.ViewportToWorldPoint(viewpos);
            }
            //左上
            if (Input.mousePosition.x < TableLeftPos.x + size
                && Input.mousePosition.y > TableTopPos.y - size)
            {
                //世界坐标
                Vector3 BallPos = SpCol.transform.position = new Vector3(Left.transform.position.x + size, 0.5f, Top.transform.position.z - size);
                //Vector3 BallPos = new Vector3(pos.x,pos.y,0);
                //视口坐标
                Vector3 viewpos = m_cMainCam.WorldToViewportPoint(BallPos);
                //UI世界坐标
                HandUI.transform.position = m_cUICam.ViewportToWorldPoint(viewpos);
            }
            //右上
            if (Input.mousePosition.x > (TablePos.x + TableLeftPos.x) / 2 - size
                && Input.mousePosition.y > TableTopPos.y)
            {
                //世界坐标
                Vector3 BallPos = SpCol.transform.position = new Vector3((Table.transform.position.x + Left.transform.position.x) / 2 - size, 0.5f, Top.transform.position.z - size);
                //Vector3 BallPos = new Vector3(pos.x,pos.y,0);
                //视口坐标
                Vector3 viewpos = m_cMainCam.WorldToViewportPoint(BallPos);
                //UI世界坐标
                HandUI.transform.position = m_cUICam.ViewportToWorldPoint(viewpos);
            }
            //左下
            if (Input.mousePosition.x < TableLeftPos.x + size
                && Input.mousePosition.y < TableDownPos.y + size)
            {
                //世界坐标
                Vector3 BallPos = SpCol.transform.position = new Vector3(Left.transform.position.x + size, 0.5f, Down.transform.position.z + size);
                //Vector3 BallPos = new Vector3(pos.x,pos.y,0);
                //视口坐标
                Vector3 viewpos = m_cMainCam.WorldToViewportPoint(BallPos);
                //UI世界坐标
                HandUI.transform.position = m_cUICam.ViewportToWorldPoint(viewpos);
            }
            //右下
            if (Input.mousePosition.x > (TablePos.x + TableLeftPos.x) / 2 - size
                && Input.mousePosition.y < TableDownPos.y + size)
            {
                //世界坐标
                Vector3 BallPos = SpCol.transform.position = new Vector3((Table.transform.position.x + Left.transform.position.x) / 2 - size, 0.5f, Down.transform.position.z + size);
                //Vector3 BallPos = new Vector3(pos.x,pos.y,0);
                //视口坐标
                Vector3 viewpos = m_cMainCam.WorldToViewportPoint(BallPos);
                //UI世界坐标
                HandUI.transform.position = m_cUICam.ViewportToWorldPoint(viewpos);
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            HandUI.SetActive(false);
            //UI坐标转为世界坐标
            Vector3 Viewpos = m_cUICam.WorldToViewportPoint(HandUI.transform.position);
            Vector3 BallPos = m_cMainCam.ViewportToWorldPoint(Viewpos);
            WhiteBall.transform.position = BallPos;
            WhiteBall.SetActive(true);
            bIsFirstPlatzieren = false;
        }
    }


    //自由球逻辑
    void Freisto()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Input.mousePosition.x < TableRightPos.x - size
                && Input.mousePosition.x > TableLeftPos.x + size
                && Input.mousePosition.y > TableDownPos.y + size
                && Input.mousePosition.y < TableTopPos.y - size)
            {
                //点击屏幕位置
                Vector3 pos = m_cMainCam.ScreenToWorldPoint(Input.mousePosition);
                //世界坐标
                Vector3 BallPos = SpCol.transform.position = new Vector3(pos.x, 0.5f, pos.z);
                //Debug.Log(pos);
                //Debug.Log(BallPos);
                //视口坐标
                Vector3 viewpos = m_cMainCam.WorldToViewportPoint(pos);
                Vector3 Viewpos = m_cMainCam.WorldToViewportPoint(BallPos);
                //UI世界坐标
                HandUI.transform.position = m_cUICam.ViewportToWorldPoint(Viewpos);
                //Debug.Log(WhiteBall.transform.position);
                //Debug.Log(m_cUICam.ViewportToWorldPoint(m_cMainCam.WorldToViewportPoint(BallPos)));
                HandUI.SetActive(true);
                SpCol.SetActive(true);
            }
            else
            {
                return;
            }
        }
        if (Input.GetMouseButton(0))
        {
            //点击屏幕位置
            Vector3 pos = m_cMainCam.ScreenToWorldPoint(Input.mousePosition);
            //Debug.Log(pos);
            //Debug.Log(Right.transform.position.x);
            //合理区域
            if (Input.mousePosition.x < TableRightPos.x - size
                && Input.mousePosition.x > TableLeftPos.x + size
                && Input.mousePosition.y > TableDownPos.y + size
                && Input.mousePosition.y < TableTopPos.y - size)
            {
                //世界坐标
                Vector3 BallPos = SpCol.transform.position = new Vector3(pos.x, 0.5f, pos.z);
                //Vector3 BallPos = new Vector3(pos.x,pos.y,0);
                //视口坐标
                Vector3 viewpos = m_cMainCam.WorldToViewportPoint(BallPos);
                //UI世界坐标
                HandUI.transform.position = m_cUICam.ViewportToWorldPoint(viewpos);
            }
            //超出右边
            if (Input.mousePosition.x > TableRightPos.x - size
                && Input.mousePosition.y > TableDownPos.y + size
                && Input.mousePosition.y < TableTopPos.y - size)
            {
                //世界坐标
                Vector3 BallPos = SpCol.transform.position = new Vector3(Right.transform.position.x - size, 0.5f, pos.z);
                //视口坐标
                Vector3 viewpos = m_cMainCam.WorldToViewportPoint(BallPos);
                //UI世界坐标
                HandUI.transform.position = m_cUICam.ViewportToWorldPoint(viewpos);
                //WhiteBall.transform.position = new Vector3(Right.transform.position.x, 0.5f, pos.z);
            }
            //超出左边
            if (Input.mousePosition.x < TableLeftPos.x + size
               && Input.mousePosition.y > TableDownPos.y + size
               && Input.mousePosition.y < TableTopPos.y - size)
            {
                //世界坐标
                Vector3 BallPos = SpCol.transform.position = new Vector3(Left.position.x + size, 0.5f, pos.z);
                //视口坐标
                Vector3 viewpos = m_cMainCam.WorldToViewportPoint(BallPos);
                //UI世界坐标
                HandUI.transform.position = m_cUICam.ViewportToWorldPoint(viewpos);
                //WhiteBall.transform.position = new Vector3(Left.transform.position.x, 0.5f, pos.z);
            }
            //超出下边
            if (Input.mousePosition.y < TableDownPos.y + size
                && Input.mousePosition.x < TableRightPos.x - size
                && Input.mousePosition.x > TableLeftPos.x + size)
            {
                //世界坐标
                Vector3 BallPos = SpCol.transform.position = new Vector3(pos.x, 0.5f, Down.position.z + size);
                //视口坐标
                Vector3 viewpos = m_cMainCam.WorldToViewportPoint(BallPos);
                //UI世界坐标
                HandUI.transform.position = m_cUICam.ViewportToWorldPoint(viewpos);
                //WhiteBall.transform.position = new Vector3(pos.x, 0.5f, Down.transform.position.z);
            }
            //超出上边
            if (Input.mousePosition.y > TableTopPos.y - size
                && Input.mousePosition.x < TableRightPos.x - size
                && Input.mousePosition.x > TableLeftPos.x + size)
            {
                //世界坐标
                Vector3 BallPos = SpCol.transform.position = new Vector3(pos.x, 0.5f, Top.position.z - size);
                //视口坐标
                Vector3 viewpos = m_cMainCam.WorldToViewportPoint(BallPos);
                //UI世界坐标
                HandUI.transform.position = m_cUICam.ViewportToWorldPoint(viewpos);
                //WhiteBall.transform.position = new Vector3(pos.x, 0.5f, Top.transform.position.z);
            }
            //左上
            if (Input.mousePosition.x < TableLeftPos.x + size
                && Input.mousePosition.y > TableTopPos.y - size)
            {
                //世界坐标
                Vector3 BallPos = SpCol.transform.position = new Vector3(Left.position.x + size, 0.5f, Top.position.z - size);
                //Vector3 BallPos = new Vector3(pos.x,pos.y,0);
                //视口坐标
                Vector3 viewpos = SpCol.transform.position = m_cMainCam.WorldToViewportPoint(BallPos);
                //UI世界坐标
                HandUI.transform.position = m_cUICam.ViewportToWorldPoint(viewpos);
            }
            //右上
            if (Input.mousePosition.x > TableRightPos.x - size
                && Input.mousePosition.y > TableTopPos.y - size)
            {
                //世界坐标
                Vector3 BallPos = SpCol.transform.position = new Vector3(Right.position.x - size, 0.5f, Top.position.z - size);
                //Vector3 BallPos = new Vector3(pos.x,pos.y,0);
                //视口坐标
                Vector3 viewpos = m_cMainCam.WorldToViewportPoint(BallPos);
                //UI世界坐标
                HandUI.transform.position = m_cUICam.ViewportToWorldPoint(viewpos);
            }
            //左下
            if (Input.mousePosition.x < TableLeftPos.x + size
                && Input.mousePosition.y < TableDownPos.y + size)
            {
                //世界坐标
                Vector3 BallPos = SpCol.transform.position = new Vector3(Left.position.x + size, 0.5f, Down.position.z + size);
                //Vector3 BallPos = new Vector3(pos.x,pos.y,0);
                //视口坐标
                Vector3 viewpos = m_cMainCam.WorldToViewportPoint(BallPos);
                //UI世界坐标
                HandUI.transform.position = m_cUICam.ViewportToWorldPoint(viewpos);
            }
            //右下
            if (Input.mousePosition.x > TableRightPos.x - size
                && Input.mousePosition.y < TableDownPos.y)
            {
                //世界坐标
                Vector3 BallPos = SpCol.transform.position = new Vector3(Right.position.x - size, 0.5f, Down.position.z + size);
                //Vector3 BallPos = new Vector3(pos.x,pos.y,0);
                //视口坐标
                Vector3 viewpos = m_cMainCam.WorldToViewportPoint(BallPos);
                //UI世界坐标
                HandUI.transform.position = m_cUICam.ViewportToWorldPoint(viewpos);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (bCanPlatzieren)
            {
                HandUI.SetActive(false);
                //UI坐标转为世界坐标
                Vector3 Viewpos = m_cUICam.WorldToViewportPoint(HandUI.transform.position);
                Vector3 BallPos = m_cMainCam.ViewportToWorldPoint(Viewpos);
                WhiteBall.transform.position = BallPos;
                WhiteBall.SetActive(true);
                bFreisto = false;
            }
            else
            {
                HandUI.transform.position = new Vector3(0, 0, 0);
            }
        }

    }

    //判断当前位置是否有球
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            DP.gameObject.SetActive(true);
            bCanPlatzieren = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ball")
        {
            DP.gameObject.SetActive(false);
            bCanPlatzieren = true;
        }
    }
}
