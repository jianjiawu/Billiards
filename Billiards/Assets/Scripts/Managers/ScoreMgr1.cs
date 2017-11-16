using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMgr1 : MonoBehaviour {

    GameObject Player1;
    GameObject Player2;
    bool bChangePlayer;
    float Player1Score;
    float Player2Score;
    TestPlatzierenBall TPB;

	// Use this for initialization
	void Start () {
        TPB = BaseActor.TPB;
	}
	
	// Update is called once per frame
	void Update () {
		//if(!bChangePlayer)
  //      {
  //          Player1Score++;
  //          Debug.Log(Player1Score);
  //      }
        if(bChangePlayer)
        {
            Player2Score++;
            Debug.Log(Player2Score);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ku")
        {
            bChangePlayer = true;
            TPB.bFreisto = true;
            gameObject.SetActive(false);
        }
    }
}
