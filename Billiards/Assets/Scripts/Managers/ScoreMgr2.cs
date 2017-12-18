using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMgr2 : MonoBehaviour {

    public bool bStartDetection;
    //是否分球结束
    public bool bFirstStart = true;
    public string Str1;
    public string Str2;

    Rigidbody RB;
	// Use this for initialization
	void Start () {
        RB = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if(Mathf.Abs(RB.velocity.x)<=0.5
            && Mathf.Abs(RB.velocity.y) <= 0.5
            && Mathf.Abs(RB.velocity.z) <= 0.5)
        {
            RB.velocity = new Vector3(0, 0, 0);
        }
		if(bStartDetection)
        {
            if(RB.velocity == new Vector3(0,0,0))
            {
                Debug.Log("Error1");
            }
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(!bFirstStart)
        {
            //碰到对方的球
            if (collision.gameObject.tag == Str2)
            {
                bStartDetection = false;
                Debug.Log("Error2");
            }
            //碰到自己的球
            if (collision.gameObject.tag == Str1)
            {
                bStartDetection = false;
                ScoreMgr3 SM3 = collision.gameObject.GetComponent<ScoreMgr3>();
                Rigidbody RB = collision.gameObject.GetComponent<Rigidbody>();
                SM3.bStartDetection = true;
            }
        }  
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Pocket")
        {
            bStartDetection = false;
            Debug.Log("Error4");
            gameObject.SetActive(false);
        }
    }
}
