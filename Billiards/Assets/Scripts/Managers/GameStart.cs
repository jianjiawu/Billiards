using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour {


	void Start () {
        BaseActor.OnStart();
        GameObject obj = new GameObject("UIManager");
        UIManager uim = obj.AddComponent<UIManager>();
        uim.UI<UIHand>();
	}
	
}
