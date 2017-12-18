using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMgr3 : MonoBehaviour {

    public bool bStartDetection;
    bool bIsTrigger;
    Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Mathf.Abs(rb.velocity.x) <= 1
        && Mathf.Abs(rb.velocity.y) <= 1
        && Mathf.Abs(rb.velocity.z) <= 1)
        {
            rb.velocity = new Vector3(0, 0, 0);
        }

        if(bStartDetection)
        {
            if (!bIsTrigger && rb.velocity == new Vector3(0, 0, 0))
            {
                Debug.Log("Error3");
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "WriteBall" && collision.gameObject.tag != "Plane")
        {
            bIsTrigger = true;
        }
    }
}
