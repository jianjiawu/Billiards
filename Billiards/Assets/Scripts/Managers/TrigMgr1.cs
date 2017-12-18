using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigMgr1 : MonoBehaviour {

    GameObject WriteBall;
    ScoreMgr2 SM2;
	// Use this for initialization
	void Start () {

    }

    private void OnTriggerEnter(Collider other)
    {
        WriteBall = GlobalHelper.g_GlobalLevel.WhiteBall;
        SM2 = WriteBall.GetComponent<ScoreMgr2>();
        if (other.tag == "Pocket")
        {
            SM2.bFirstStart = false;
            SM2.Str1 = gameObject.tag.ToString();
            SM2.Str1 = "Ball";
            SM2.Str2 = "ball";
        }
    }
}
