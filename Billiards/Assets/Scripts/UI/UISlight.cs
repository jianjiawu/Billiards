using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISlight : MonoBehaviour {

    public GameObject m_oBall;
    public GameObject m_oBack;
    public GameObject m_oFront;
    public GameObject m_oUIClub;
    public GameObject m_oClub;
    public GameObject m_oLine;
    public GameObject m_oClubButton;
    public GameObject m_oBallButton;
    public GameObject m_oButton;

    // Use this for initialization
    void Start()
    {
        UIEventListener.Get(m_oClubButton).onClick = Change;
        UIEventListener.Get(m_oBallButton).onClick = Ball;
        UIEventListener.Get(m_oButton).onClick = But;
    }

    void Change(GameObject obj)
    {
        //Debug.Log("111");
        obj.SetActive(false);
        m_oUIClub.transform.localScale = new Vector3(3f,3f,3f);
        m_oUIClub.transform.localPosition = new Vector3(0, -1000, 0);
        m_oBall.transform.localScale = new Vector3(1f, 1f, 1f);
        m_oBall.transform.localPosition = new Vector3(2750, -2000, 0);
        m_oBallButton.SetActive(true);
    }

    void Ball(GameObject obj)
    {
        m_oUIClub.SetActive(true);
        //Debug.Log("baobao");
        obj.SetActive(false);
        m_oUIClub.transform.localScale = new Vector3(1f, 1f, 1f);
        m_oUIClub.transform.localPosition = new Vector3(-2750, -2000, 0);
        m_oBall.transform.localScale = new Vector3(3f, 3f, 3f);
        m_oBall.transform.localPosition = new Vector3(0, -1000, 0);
        m_oClubButton.SetActive(true);
    }

    void But(GameObject obj)
    {
        m_oUIClub.SetActive(true);
        m_oBall.SetActive(true);
        m_oUIClub.transform.localScale = new Vector3(1f, 1f, 1f);
        m_oUIClub.transform.localPosition = new Vector3(-2750, -2000, 0);
        m_oBall.transform.localScale = new Vector3(3f, 3f, 3f);
        m_oBall.transform.localPosition = new Vector3(0, -1000, 0);
        m_oClubButton.SetActive(true);
    }
}
