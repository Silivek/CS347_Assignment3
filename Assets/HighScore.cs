﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
	static public int score = 1000;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	
        GameObject highScoreGO=GameObject.Find("HighScore");
        Text gt = highScoreGO.GetComponent<Text>();
    	gt.text = "Hight Score: "+score;
        
    }
}
