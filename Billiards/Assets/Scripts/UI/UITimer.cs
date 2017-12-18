using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITimer : MonoBehaviour {

    public UISlider Timer1;
    public UISlider Timer2;
    bool bPlayer1Hit = true;
    bool bPlayer2Hit = false;
	// Use this for initialization
	void Start () {


    }
	
	// Update is called once per frame
	void Update () {
		if(bPlayer1Hit)
        {
            StartCoroutine(ClucateTime1());
        }
        if (bPlayer2Hit)
        {
            StartCoroutine(ClucateTime2());
        }
    }

    IEnumerator ClucateTime1()
    {
        yield return new WaitForSeconds(0.1f);
        Timer1.value -= 1/300f;
        if(Timer1.value == 0)
        {
            Debug.Log("Error5");
            bPlayer2Hit = true;
            bPlayer1Hit = false;
            Timer1.value = 1;
        }
    }

    IEnumerator ClucateTime2()
    {
        yield return new WaitForSeconds(0.1f);
        Timer2.value -= 1 / 300f;
        if (Timer2.value == 0)
        {
            Debug.Log("Error6");
            bPlayer1Hit = true;
            bPlayer2Hit = false;
            Timer2.value = 1;
        }

    }
}
