//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class SphereCollider1 : MonoBehaviour
//{

//    public GameObject WhiteBall;
//    TestPlatzierenBall TPB;

//    private void Start()
//    {
//        TPB = WhiteBall.GetComponent<TestPlatzierenBall>();
//    }
//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.tag == "Ball")
//        {
//            TPB.bFreisto = true;
//            Destroy(gameObject);
//        }
//        if (other.tag == "Plane")
//        {
//            WhiteBall.SetActive(true);
//        }
//        if (other.tag == "Wall")
//        {
//            TPB.bFreisto = true;
//            Destroy(gameObject);
//        }
//    }


//    void Anstossen()
//    {
//        if (Input.GetMouseButtonDown(0))
//        {
//            if (Input.mousePosition.x < (TablePos.x + TableLeftPos.x) / 2
//                && Input.mousePosition.x > TableLeftPos.x
//                && Input.mousePosition.y > TableDownPos.y
//                && Input.mousePosition.y < TableTopPos.y)
//            {
//                Vector3 pos = m_cMainCam.ScreenToWorldPoint(Input.mousePosition);
//                WhiteBall.transform.position = new Vector3(pos.x, 0.5f, pos.z);
//                WhiteBall.SetActive(true);
//                点击屏幕位置
//                Vector3 pos = m_cMainCam.ScreenToWorldPoint(Input.mousePosition);
//                世界坐标
//                Vector3 BallPos = new Vector3(pos.x, 0.5f, pos.z);
//                Debug.Log(pos);
//                Debug.Log(BallPos);
//                视口坐标
//                Vector3 viewpos = m_cMainCam.WorldToViewportPoint(pos);
//                Vector3 Viewpos = m_cMainCam.WorldToViewportPoint(BallPos);
//                UI世界坐标
//                HandUI.transform.position = m_cUICam.ViewportToWorldPoint(Viewpos);
//                Debug.Log(WhiteBall.transform.position);
//                Debug.Log(m_cUICam.ViewportToWorldPoint(m_cMainCam.WorldToViewportPoint(BallPos)));
//                HandUI.SetActive(true);
//            }
//            else
//            {
//                return;
//            }
//        }
//        if (Input.GetMouseButton(0))
//        {
//            合理区域
//            Vector3 pos = m_cMainCam.ScreenToWorldPoint(Input.mousePosition);
//            if (Input.mousePosition.x < (TablePos.x + TableLeftPos.x) / 2
//                 && Input.mousePosition.x > TableLeftPos.x
//                 && Input.mousePosition.y > TableDownPos.y
//                && Input.mousePosition.y < TableTopPos.y)
//            {
//                WhiteBall.transform.position = new Vector3(pos.x, 0.5f, pos.z);
//                世界坐标
//                Vector3 BallPos = new Vector3(pos.x, 0.5f, pos.z);
//                Vector3 BallPos = new Vector3(pos.x, pos.y, 0);
//                视口坐标
//                Vector3 viewpos = m_cMainCam.WorldToViewportPoint(BallPos);
//                UI世界坐标
//                HandUI.transform.position = m_cUICam.ViewportToWorldPoint(viewpos);
//            }
//            超出右边
//            if (Input.mousePosition.x > (TablePos.x + TableLeftPos.x) / 2
//                && Input.mousePosition.y > TableDownPos.y
//                && Input.mousePosition.y < TableTopPos.y)
//            {
//                坐标转换
//                Vector3 Pos = new Vector3((Table.transform.position.x + Left.transform.position.x) / 2, 0.5f, pos.z);
//                Vector3 ViewPos = m_cMainCam.WorldToViewportPoint(Pos);
//                WhiteBall.transform.position = new Vector3((Table.transform.position.x + Left.transform.position.x) / 2, 0.5f, pos.z);
//                世界坐标
//                Vector3 BallPos = new Vector3((Table.transform.position.x + Left.transform.position.x) / 2, 0.5f, pos.z);
//                视口坐标
//                Vector3 viewpos = m_cMainCam.WorldToViewportPoint(BallPos);
//                UI世界坐标
//                HandUI.transform.position = m_cUICam.ViewportToWorldPoint(viewpos);
//            }
//            超出左边
//            if (Input.mousePosition.x < TableLeftPos.x
//               && Input.mousePosition.y > TableDownPos.y
//               && Input.mousePosition.y < TableTopPos.y)
//            {
//                WhiteBall.transform.position = new Vector3(Left.transform.position.x, 0.5f, pos.z);
//                世界坐标
//                Vector3 BallPos = new Vector3(Left.transform.position.x, 0.5f, pos.z);
//                视口坐标
//                Vector3 viewpos = m_cMainCam.WorldToViewportPoint(BallPos);
//                UI世界坐标
//                HandUI.transform.position = m_cUICam.ViewportToWorldPoint(viewpos);
//            }
//            超出下边
//            if (Input.mousePosition.y < TableDownPos.y
//                && Input.mousePosition.x < (TablePos.x + TableLeftPos.x) / 2
//                && Input.mousePosition.x > TableLeftPos.x)
//            {
//                WhiteBall.transform.position = new Vector3(pos.x, 0.5f, Down.transform.position.z);
//                世界坐标
//                Vector3 BallPos = new Vector3(pos.x, 0.5f, Down.transform.position.z);
//                视口坐标
//                Vector3 viewpos = m_cMainCam.WorldToViewportPoint(BallPos);
//                UI世界坐标
//                HandUI.transform.position = m_cUICam.ViewportToWorldPoint(viewpos);
//            }
//            超出上边
//            if (Input.mousePosition.y > TableTopPos.y
//                && Input.mousePosition.x < (TablePos.x + TableLeftPos.x) / 2
//                && Input.mousePosition.x > TableLeftPos.x)
//            {
//                WhiteBall.transform.position = new Vector3(pos.x, 0.5f, Top.transform.position.z);
//                世界坐标
//                Vector3 BallPos = new Vector3(pos.x, 0.5f, Top.transform.position.z);
//                视口坐标
//                Vector3 viewpos = m_cMainCam.WorldToViewportPoint(BallPos);
//                UI世界坐标
//                HandUI.transform.position = m_cUICam.ViewportToWorldPoint(viewpos);
//            }
//            左上
//            if (Input.mousePosition.x < TableLeftPos.x
//                && Input.mousePosition.y > TableTopPos.y)
//            {
//                世界坐标
//                Vector3 BallPos = new Vector3(Left.transform.position.x, 0.5f, Top.transform.position.z);
//                Vector3 BallPos = new Vector3(pos.x, pos.y, 0);
//                视口坐标
//                Vector3 viewpos = m_cMainCam.WorldToViewportPoint(BallPos);
//                UI世界坐标
//                HandUI.transform.position = m_cUICam.ViewportToWorldPoint(viewpos);
//            }
//            右上
//            if (Input.mousePosition.x > (TablePos.x + TableLeftPos.x) / 2
//                && Input.mousePosition.y > TableTopPos.y)
//            {
//                世界坐标
//                Vector3 BallPos = new Vector3((Table.transform.position.x + Left.transform.position.x) / 2, 0.5f, Top.transform.position.z);
//                Vector3 BallPos = new Vector3(pos.x, pos.y, 0);
//                视口坐标
//                Vector3 viewpos = m_cMainCam.WorldToViewportPoint(BallPos);
//                UI世界坐标
//                HandUI.transform.position = m_cUICam.ViewportToWorldPoint(viewpos);
//            }
//            左下
//            if (Input.mousePosition.x < TableLeftPos.x
//                && Input.mousePosition.y < TableDownPos.y)
//            {
//                世界坐标
//                Vector3 BallPos = new Vector3(Left.transform.position.x, 0.5f, Down.transform.position.z);
//                Vector3 BallPos = new Vector3(pos.x, pos.y, 0);
//                视口坐标
//                Vector3 viewpos = m_cMainCam.WorldToViewportPoint(BallPos);
//                UI世界坐标
//                HandUI.transform.position = m_cUICam.ViewportToWorldPoint(viewpos);
//            }
//            右下
//            if (Input.mousePosition.x > (TablePos.x + TableLeftPos.x) / 2
//                && Input.mousePosition.y < TableDownPos.y)
//            {
//                世界坐标
//                Vector3 BallPos = new Vector3((Table.transform.position.x + Left.transform.position.x) / 2, 0.5f, Down.transform.position.z);
//                Vector3 BallPos = new Vector3(pos.x, pos.y, 0);
//                视口坐标
//                Vector3 viewpos = m_cMainCam.WorldToViewportPoint(BallPos);
//                UI世界坐标
//                HandUI.transform.position = m_cUICam.ViewportToWorldPoint(viewpos);
//            }
//        }
//        if (Input.GetMouseButtonUp(0))
//        {
//            HandUI.SetActive(false);
//            UI坐标转为世界坐标
//            Vector3 Viewpos = m_cUICam.WorldToViewportPoint(HandUI.transform.position);
//            Vector3 BallPos = m_cMainCam.ViewportToWorldPoint(Viewpos);
//            WhiteBall.transform.position = BallPos;
//            WhiteBall.SetActive(true);
//            bIsFirstPlatzieren = false;
//        }
//    }
//}
