﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    private void OnGUI()
    {
        if(GUI.Button(new Rect(0,0,100,100),"Press"))
        {
            BaseActor.TPB.bFreisto = true;
        }
    }
}
