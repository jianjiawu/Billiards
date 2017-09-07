//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class SpCol : MonoBehaviour {

//    GameObject UIMgr;
//    UIManager UIM;
//    UIHand UIh;
//    GameObject Hand;
//    GameObject DP;

//    private void Start()
//    {
//        UIMgr = GameObject.Find("UIManager");
//        UIM = UIMgr.GetComponent<UIManager>();
//        UIh = UIM.UI<UIHand>(false);
//        if(DP == null)
//        {
//            for(int i=0;i<UIh.gameObject.transform.childCount;i++)
//            {
//                if(UIh.gameObject.transform.GetChild(i).name == "DontPush")
//                {
//                    DP = UIh.gameObject.transform.GetChild(i).gameObject;
//                }
//            }
//        }
//        if (Hand == null)
//        {
//            for (int i = 0; i < UIh.gameObject.transform.childCount; i++)
//            {
//                if (UIh.gameObject.transform.GetChild(i).name == "Hand")
//                {
//                    Hand = UIh.gameObject.transform.GetChild(i).gameObject;
//                }
//            }
//        }
//    }

//    private void Update()
//    {
//        DP.transform.position = Hand.transform.position;
//    }

//    private void OnTriggerEnter(Collider other)
//    {
//        if(other.tag == "Ball")
//        {
//            DP.gameObject.SetActive(true);
//        }
//    }
//    private void OnTriggerExit(Collider other)
//    {
//        if(other.tag == "Ball")
//        {
//            DP.gameObject.SetActive(false);
//        }
//    }
//}
